using System;

namespace MuseumApi.Models
{
  public class Museum
  {
    public Guid MuseumID { get; set; }

    public string Name { get; set; }

    public string? Theme { get; set; }

    public virtual ICollection<Article>? Articles { get; set; }
  }
}
