using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuseumApi.DAL;
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
          if (_context.Museums == null)
          {
              return NotFound();
          }
            return await _context.Museums.ToListAsync();
        }

        // GET: api/Museum/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Museum>> GetMuseum(Guid id)
        {
          if (_context.Museums == null)
          {
              return NotFound();
          }
            var museum = await _context.Museums.FindAsync(id);

            if (museum == null)
            {
                return NotFound();
            }

            return museum;
        }

    [HttpGet("theme/{theme}")]
    public async Task<ActionResult<IEnumerable<Museum>>> GetMuseumByTheme(string theme)
    {
      if (_context.Museums == null)
      {
        return NotFound();
      }
      var museums = await _context.Museums.Where(museum => museum.Theme == theme).ToListAsync();

      

      return museums;
    }

        // PUT: api/Museum/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMuseum(Guid id, Museum museum)
        {
            if (id != museum.MuseumID)
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
          if (_context.Museums == null)
          {
              return Problem("Entity set 'Museumcontext.Museums'  is null.");
          }
            _context.Museums.Add(museum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMuseum", new { id = museum.MuseumID }, museum);
        }

        // DELETE: api/Museum/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMuseum(Guid id)
        {
            if (_context.Museums == null)
            {
                return NotFound();
            }
            var museum = await _context.Museums.FindAsync(id);
            if (museum == null)
            {
                return NotFound();
            }

            _context.Museums.Remove(museum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MuseumExists(Guid id)
        {
            return (_context.Museums?.Any(e => e.MuseumID == id)).GetValueOrDefault();
        }
    }
}
