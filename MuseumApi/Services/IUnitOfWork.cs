using System;
using MuseumApi.Repositories;
namespace MuseumApi.Services
{
  public interface IUnitOfWork : IDisposable
  {
    public MuseumRepository Museums { get; }
    public ArticleRepository Articles { get; }
    int Save();
  }
}