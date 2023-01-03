using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuseumApi.Contexts;
using MuseumApi.Models;

namespace MuseumApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuseumController : ControllerBase
    {
        private readonly MuseumContext _context;

        public MuseumController(MuseumContext context)
        {
            _context = context;
        }

        // GET: api/Museum
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Museum>>> Getmuseums()
        {
          if (_context.museums == null)
          {
              return NotFound();
          }
            return await _context.museums.ToListAsync();
        }

        // GET: api/Museum/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Museum>> GetMuseum(Guid id)
        {
          if (_context.museums == null)
          {
              return NotFound();
          }
            var museum = await _context.museums.FindAsync(id);

            if (museum == null)
            {
                return NotFound();
            }

            return museum;
        }

        // PUT: api/Museum/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMuseum(Guid id, Museum museum)
        {
            if (id != museum.id)
            {
                return BadRequest();
            }

            _context.Entry(museum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MuseumExists(id))
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

        // POST: api/Museum
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Museum>> PostMuseum(Museum museum)
        {
          if (_context.museums == null)
          {
              return Problem("Entity set 'MuseumContext.museums'  is null.");
          }
            _context.museums.Add(museum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMuseum", new { id = museum.id }, museum);
        }

        // DELETE: api/Museum/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMuseum(Guid id)
        {
            if (_context.museums == null)
            {
                return NotFound();
            }
            var museum = await _context.museums.FindAsync(id);
            if (museum == null)
            {
                return NotFound();
            }

            _context.museums.Remove(museum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MuseumExists(Guid id)
        {
            return (_context.museums?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
