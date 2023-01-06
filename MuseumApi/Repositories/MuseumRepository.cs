using Microsoft.EntityFrameworkCore;
using MuseumApi.Models;
using MuseumApi.DAL;

namespace MuseumApi.Repositories
{
  public class MuseumRepository : GenericRepository<Museum>
  {
    public MuseumRepository(MuseumContext context) : base(context)
    {
      Initialize();
    }

    public async void Initialize()
    {
      // Look for any museum.
      if (_context.Museums.Any())
      {
        return;   // Data was already seeded
      }

      // Initialize data
      await _context.Themes.AddRangeAsync(
      new Theme
      {
        ThemeID = 1,
        name = "Art"
      },
      new Theme
      {
        ThemeID = 2,
        name = "History"
      },
      new Theme
      {
        ThemeID = 3,
        name = "Natural Science"
      });
      await _context.Museums.AddRangeAsync(
          new Museum
          {
            Name = "Art Museum",
            ThemeID = 1,
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
            Name = "History Museum",
            ThemeID = 2,
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
            Name = "Science Museum",
            ThemeID = 3
          }
      );

      _context.SaveChanges();
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

    public async Task<List<Theme>> GetThemes()
    {
      var themes = await _context.Themes.ToListAsync();

      return themes;
    }
  }
}