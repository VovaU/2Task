using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.Models;

namespace WebApplication7.Persistence
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly InformationContext _context;

        public UnitOfWork(InformationContext context)
        {
            _context = context;
        }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }

    public interface IUnitOfWork
    {
        Task Complete();
    }
}
