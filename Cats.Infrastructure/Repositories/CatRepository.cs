using Cats.Domain.Entities;
using Cats.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cats.Domain.Repositories
{
    public class CatRepository : ICatRepository
    {
        private readonly CatApiContext _context;

        public CatRepository(CatApiContext context)
        {
            _context = context;
        }

        public IQueryable<Cat> GetCats()
        {
            return  _context.Cats;
        }
    }
}
