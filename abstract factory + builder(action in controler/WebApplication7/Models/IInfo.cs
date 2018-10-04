using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication7.Models
{
    public interface IInfo
    {
        int Id { get; set; }
        string Title { get; set; }
        string Body { get; set; }
        DateTime CreationDate { get; set; }
        string Author { get; set; }
    }
}
