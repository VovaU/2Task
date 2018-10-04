using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication7.Models
{
    public class InformationContext : DbContext
    {
        public InformationContext(DbContextOptions<InformationContext> options)
            : base(options)
        { }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Topic> Topics { get; set; }
    }
}
