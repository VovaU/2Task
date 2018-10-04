using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication7.Models
{
    public abstract class IBuilder
    {
        public abstract void BuildTitle(string title);
        public abstract void BuildBody(string body);
        public abstract void BuildCreationDate();
        public abstract void BuildAuthor(string author);
        public abstract IInfo Result();
        public abstract void Build();
    }
}
