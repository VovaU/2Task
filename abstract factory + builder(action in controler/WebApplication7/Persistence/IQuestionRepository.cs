using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.Models;

namespace WebApplication7.Persistence
{
    public interface IQuestionRepository
    {
        Task<Question> GetQuestion(int id);
        void CreateQuestion(Question question);
        void DeleteQuestion(Question question);
    }
}
