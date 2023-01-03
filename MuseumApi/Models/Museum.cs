using System;

namespace MuseumApi.Models
{
  public class Museum
  {
    public Guid MuseumID { get; set; }

    public string Name { get; set; }

    public Theme? Theme { get; set; }

    public virtual ICollection<Article> Articles { get; set; }
  }
}

public enum Theme
{
  Art,
  NaturalScience,
  History
}
