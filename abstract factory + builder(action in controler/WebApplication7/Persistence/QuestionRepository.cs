using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication7.Models;

namespace WebApplication7.Persistence
{
    public class QuestionRepository:IQuestionRepository
    {
        private readonly InformationContext _context;
        public QuestionRepository(InformationContext context)
        {
            _context = context;
        }

        public async Task<Question> GetQuestion(int id)
        {
            return await _context.Questions.SingleOrDefaultAsync(q => q.Id == id);
        }

        public void CreateQuestion(Question question)
        {
            _context.Questions.Add(question);
        }

        public void DeleteQuestion(Question question)
        {
            _context.Questions.Remove(question);
        }
    }
}
