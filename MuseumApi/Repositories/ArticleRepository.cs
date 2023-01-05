using Microsoft.EntityFrameworkCore;
using MuseumApi.Models;
using MuseumApi.DAL;

namespace MuseumApi.Repositories
{
  public class ArticleRepository : GenericRepository<Article>
  {
    public ArticleRepository(MuseumContext context) : base(context)
    {

    }
  }
}
