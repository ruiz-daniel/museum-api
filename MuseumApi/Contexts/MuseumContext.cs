using MuseumApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MuseumApi.Contexts;

public class MuseumContext : DbContext
{
  public MuseumContext(DbContextOptions<MuseumContext> options)
        : base(options)
  {
  }
  public DbSet<Museum> museums { get; set; } = null!;
}