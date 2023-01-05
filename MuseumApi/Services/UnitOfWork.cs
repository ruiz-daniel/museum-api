using MuseumApi.DAL;
using MuseumApi.Repositories;

namespace MuseumApi.Services
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly MuseumContext _context;

    public UnitOfWork(MuseumContext context)
    {
      _context = context;
      Museums = new MuseumRepository(_context);
      Articles = new ArticleRepository(_context);
    }

    public MuseumRepository Museums { get; private set; }
    public ArticleRepository Articles { get; private set; }

    public int Save()
    {
      return _context.SaveChanges();
    }

    public void Dispose()
    {
      _context.Dispose();
    }
  }
}
