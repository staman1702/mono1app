using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Service0.Persistence.Contexts;

namespace Project.Service0.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
