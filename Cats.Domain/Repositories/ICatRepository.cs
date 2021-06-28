using Cats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cats.Domain.Repositories
{
    public interface ICatRepository
    {
        public IQueryable<Cat> GetCats();
    }
}
