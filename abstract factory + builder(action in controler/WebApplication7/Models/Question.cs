using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication7.Models
{
    public class Question:IInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public string Author { get; set; }
    }
}
