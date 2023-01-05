using Microsoft.EntityFrameworkCore;
using MuseumApi.Models;
using MuseumApi.DAL;

namespace MuseumApi.Repositories
{
  public class MuseumRepository : GenericRepository<Museum>
  {
    public MuseumRepository(MuseumContext context) : base(context)
    {

    }

    new public async Task<Museum> Find(Guid id)
    {
      var museum = await _context.Museums.FindAsync(id);

      if (museum != null)
      {
        var articles = await _context.Articles.Where(article => article.MuseumID == museum.MuseumID).ToListAsync();
        museum.Articles = articles;
      }

      return museum;
    }
  }
}