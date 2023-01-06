using Microsoft.EntityFrameworkCore;
using MuseumApi.Models;
using MuseumApi.DAL;

using System.Linq;
using System.Linq.Expressions;

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

    new public async Task<List<Museum>> FindAll()
    {
      var museums = await _context.Museums.ToListAsync();

      foreach (Museum museum in museums)
      {
        var theme = await _context.Themes.FindAsync(museum.ThemeID);
        museum.Theme = theme;
      }

      return museums;
    }

    new public async Task<Museum> Find(Guid id)
    {
      var museum = await _context.Museums.FindAsync(id);

      if (museum != null)
      {
        var articles = await _context.Articles.Where(article => article.MuseumID == museum.MuseumID).ToListAsync();
        museum.Articles = articles;

        var theme = await _context.Themes.FindAsync(museum.ThemeID);
        museum.Theme = theme;
      }

      return museum;
    }

    new public async Task<List<Museum>> FindBy(Expression<Func<Museum, bool>> expression)
    {
      var museums = await _context.Set<Museum>().Where(expression).ToListAsync();

      foreach (Museum museum in museums)
      {
        var theme = await _context.Themes.FindAsync(museum.ThemeID);
        museum.Theme = theme;
      }

      return museums;

    }

    public async Task<List<Theme>> GetThemes()
    {
      var themes = await _context.Themes.ToListAsync();

      return themes;
    }
  }
}