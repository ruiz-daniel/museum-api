using System;

namespace MuseumApi.Models
{
  public class Museum
  {
    public Guid MuseumID { get; set; }

    public string Name { get; set; }

    public int ThemeID { get; set; }

    public virtual Theme? Theme { get; set; }

    public virtual ICollection<Article>? Articles { get; set; }
  }
}
