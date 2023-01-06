using Microsoft.EntityFrameworkCore;
using MuseumApi.Models;
using MuseumApi.DAL;

using System.Linq;
using System.Linq.Expressions;

namespace MuseumApi.Repositories
{
  public class ArticleRepository : GenericRepository<Article>
  {
    public ArticleRepository(MuseumContext context) : base(context)
    {
      
    }

    new public async Task<List<Article>> FindBy(Expression<Func<Article, bool>> expression)
    {
      var articles = await _context.Articles.Where(expression).ToListAsync();

      // foreach (Article article in articles)
      // {
      //   article.Museum = await _context.Museums.FindAsync(article.MuseumID);
      // }

      return articles;
    }
  }
}
