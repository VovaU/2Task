using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication7.Models
{
    public class TopicBuilder : IBuilder
    {
        private Topic topic;

        public override void Build()
        {
           topic = new Topic();
        }
        public Topic ResultTopic()
        {
            return topic;
        }

        public override IInfo Result()
        {
            return topic;
        }
        public override void BuildTitle(string title)
        {
            topic.Title = $"This is Title: {title} | Topic";
        }

        public override void BuildBody(string body)
        {
            topic.Body = $"This is Body: {body} | Topic";
        }

        public override void BuildCreationDate()
        {
            topic.CreationDate = DateTime.Now;
        }

        public override void BuildAuthor(string author)
        {
            topic.Author = $"This is Author: {author} | Topic";
        }
    }

}
