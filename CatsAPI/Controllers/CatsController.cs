using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cats.Domain.Entities;
using Cats.Infrastructure;
using Cats.Domain.Services;

namespace Cats.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        private readonly CatApiContext _context;
        private ICatService _catService;

        public CatsController(CatApiContext context, ICatService catService)
        {
            _context = context;
            _catService = catService;
        }

        // GET: api/Cats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cat>>> GetCats()
        {
            return await _context.Cats.ToListAsync();
        }

        [Route("fivecats")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cat>>> GetFiveCats()
        {
            return await _context.Cats.Take(5).ToListAsync();
        }

        // GET: api/Cats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cat>> GetCat(Guid id)
        {
            var cat = await _context.Cats.FindAsync(id);

            if (cat == null)
            {
                return NotFound();
            }

            return cat;
        }

        // PUT: api/Cats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCat(Guid id, Cat cat)
        {
            if (id != cat.CatId)
            {
                return BadRequest();
            }

            _context.Entry(cat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cat>> PostCat(Cat cat)
        {
            _context.Cats.Add(cat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCat", new { id = cat.CatId }, cat);
        }

        // DELETE: api/Cats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCat(Guid id)
        {
            var cat = await _context.Cats.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }

            _context.Cats.Remove(cat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CatExists(Guid id)
        {
            return _context.Cats.Any(e => e.CatId == id);
        }
    }
}
