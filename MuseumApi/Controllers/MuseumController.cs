using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuseumApi.DAL;
using MuseumApi.Models;
using MuseumApi.Services;

namespace MuseumApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MuseumController : ControllerBase
  {
    private readonly IUnitOfWork _repositories;

    public MuseumController(IUnitOfWork unitOfWork)
    {
      _repositories = unitOfWork;
    }

    // GET: api/Museum
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Museum>>> GetMuseums()
    {
      return await _repositories.Museums.FindAll();
    }

    // GET: api/Museum/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Museum>> GetMuseum(Guid id)
    {
      var museum = await _repositories.Museums.Find(id);

      if (museum == null)
      {
        return NotFound();
      }

      return museum;
    }

    [HttpGet("theme/{themeID}")]
    public async Task<ActionResult<IEnumerable<Museum>>> GetMuseumByTheme(int themeID)
    {

      var museums = await _repositories.Museums.FindBy(museum => museum.ThemeID == themeID);

      return museums;
    }

    // PUT: api/Museum/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut]
    public async Task<IActionResult> PutMuseum(Museum museum)
    {
      try
      {
        await _repositories.Museums.UpdateAsync(museum);
      }
      catch (DbUpdateConcurrencyException)
      {
        throw;
      }

      return NoContent();
    }

    // POST: api/Museum
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Museum>> PostMuseum(Museum museum)
    {
      await _repositories.Museums.CreateAsync(museum);

      return CreatedAtAction("GetMuseum", new { id = museum.MuseumID }, museum);
    }

    // DELETE: api/Museum/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMuseum(Guid id)
    {

      var museum = await _repositories.Museums.Find(id);
      if (museum == null)
      {
        return NotFound();
      }
      await _repositories.Museums.DeleteAsync(museum);

      return NoContent();
    }

    [HttpGet("theme/")]
    public async Task<ActionResult<IEnumerable<Theme>>> GetThemes()
    {
      return await _repositories.Museums.GetThemes();
    }

     
  }
}
