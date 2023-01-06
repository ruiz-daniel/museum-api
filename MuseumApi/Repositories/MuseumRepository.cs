using Microsoft.EntityFrameworkCore;
using MuseumApi.Models;
using MuseumApi.DAL;

namespace MuseumApi.Repositories
{
  public class MuseumRepository : GenericRepository<Museum>
  {
    public MuseumRepository(MuseumContext context) : base(context)
    {

      // Look for any museum.
      if (context.Museums.Any())
      {
        return;   // Data was already seeded
      }

      // Initialize data
      context.Museums.AddRange(
          new Museum
          {
            Name = "Art Museum",
            Theme = "Art",
            Articles = new List<Article>() {
                    new Article {
                        Name = "Painting 1",
                    },
                    new Article {
                        Name = "Sculpture 1",
                    },
                    new Article {
                        Name = "Painting 2",
                    },
                    new Article {
                        Name = "Sculpture 2",
                    },
              }
          },
          new Museum
          {
            Name = "Histtory Museum",
            Theme = "History",
            Articles = new List<Article>() {
                    new Article {
                        Name = "Statue 1",
                    },
                    new Article {
                        Name = "Portrait 1",
                    },
                    new Article {
                        Name = "Portrait 2",
                    }
              }
          },
          new Museum
          {
            Name = "Science",
            Theme = "Natural Science"
          }
      );

      context.SaveChanges();

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