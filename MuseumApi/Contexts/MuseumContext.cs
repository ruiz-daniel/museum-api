using MuseumApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MuseumApi.Contexts;

public class MuseumContext : DbContext
{
  public MuseumContext(DbContextOptions<MuseumContext> options)
        : base(options)
  {
  }
  public DbSet<Museum> Museums { get; set; } = null!;
  public DbSet<Article> Articles { get; set; } = null!;
}