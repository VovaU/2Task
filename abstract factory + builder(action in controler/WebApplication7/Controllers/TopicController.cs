using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;
using WebApplication7.Persistence;
using WebApplication7.ViewModels;

namespace WebApplication7.Controllers
{
    [Route("api/topic")]
    [ApiController]
    public class TopicController : Controller
    {
        private readonly InformationContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TopicController(IMapper mapper, InformationContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTopic(TopicViewModel topicViewModel)
        {
            Creator creator = new ConcreateCreator();
            IBuilder builder = creator.Create(ArtType.Topic);
            builder.Build();
            builder.BuildAuthor(topicViewModel.Author);
            builder.BuildBody(topicViewModel.Body);
            builder.BuildCreationDate();
            builder.BuildTitle(topicViewModel.Title);
            Topic topic = builder.Result() as Topic;
            _context.Topics.Add(topic);
            await _unitOfWork.Complete();
            return Json(topic);
        }
        [HttpGet("{id}")]
        public IActionResult GetTopic(int id)
        {
            Topic topic = _context.Topics.SingleOrDefault(q => q.Id == id);
            if (topic == null)
            {
                return StatusCode(404);
            }
            return Json(topic);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            Topic topic = _context.Topics.SingleOrDefault(q => q.Id == id);
            if (topic == null)
            {
                return StatusCode(404);
            }

            _context.Topics.Remove(topic);
            await _unitOfWork.Complete();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTopic(int id, [FromBody] TopicViewModel bodyTopic)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Topic topic = _context.Topics.SingleOrDefault(q => q.Id == id);
            if (topic == null)
                return NotFound();
            _mapper.Map<TopicViewModel, Topic>(bodyTopic, topic);
            topic.CreationDate = DateTime.Now;
            await _unitOfWork.Complete();
            return Ok(topic);
        }
    }
}