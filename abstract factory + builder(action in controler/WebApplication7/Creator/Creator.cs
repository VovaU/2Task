using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication7.Models
{
    public abstract class Creator
    {
        public abstract IBuilder Create(ArtType type);
    }
    public class ConcreateCreator : Creator
    {
        public override IBuilder Create(ArtType type)
        {
            switch (type)
            {
                case ArtType.Question:
                {
                    return new QuestionBuilder();
                }
                case ArtType.Topic:
                {
                    return new TopicBuilder();
                }
            }

            return null;
        }
    }
}
