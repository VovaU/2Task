using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication7.Models
{
    public class QuestionBuilder : IBuilder
    {
        private Question question;

        public Question ResultQuestion()
        {
            return question;
        }

        public override IInfo Result()
        {
            return question;
        }

        public override void Build()
        {
            question=new Question();
        }
        public override void BuildTitle(string title)
        {
            question.Title = $"This is Title: {title} | Question";
        }

        public override void BuildBody(string body)
        {
            question.Body = $"This is Body: {body} | Question";
        }

        public override void BuildCreationDate()
        {
            question.CreationDate = DateTime.Now.Date;
        }

        public override void BuildAuthor(string author)
        {
            question.Author = $"This is Author:{author} | Question";
        }
    }

}
