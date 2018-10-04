using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication7.Models;
using WebApplication7.Persistence;
using WebApplication7.ViewModels;

namespace WebApplication7.Controllers
{
    [Route("api/question")]
    [ApiController]
    public class QuestionController : Controller
    {
        private readonly InformationContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;

        public QuestionController(IMapper mapper, InformationContext context,IUnitOfWork unitOfWork, IQuestionRepository questionRepository)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _questionRepository = questionRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuestion(QuestionViewModel questionViewModel)
        {
            Creator creator = new ConcreateCreator();
            IBuilder builder = creator.Create(ArtType.Question);
            builder.Build();
            builder.BuildAuthor(questionViewModel.Author);
            builder.BuildBody(questionViewModel.Body);
            builder.BuildCreationDate();
            builder.BuildTitle(questionViewModel.Title);
            Question question = builder.Result() as Question;
            _questionRepository.CreateQuestion(question);
            await _unitOfWork.Complete();
            return Json(question);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion(int id)
        {
            Question question = await _questionRepository.GetQuestion(id);
            if (question == null)
            {
                return StatusCode(404);
            }
            return Json(question);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            Question question = await _questionRepository.GetQuestion(id);
            if (question == null)
            {
                return StatusCode(404);
            }

           _questionRepository.DeleteQuestion(question);
            await _unitOfWork.Complete();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id,[FromBody] QuestionViewModel bodyQuestion)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Question question = await _questionRepository.GetQuestion(id);
            if (question == null)
                return NotFound();
            _mapper.Map<QuestionViewModel, Question>(bodyQuestion, question);
            question.CreationDate=DateTime.Now;
            await _unitOfWork.Complete();
            return Ok(question);
        }
    }
}