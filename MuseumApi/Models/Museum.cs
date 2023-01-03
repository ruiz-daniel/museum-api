using System;

namespace MuseumApi.Models
{
  public class Museum
  {
    public Guid id { get; set; }

    public string name { get; set; }

    public Theme theme { get; set; }
  }
}

public enum Theme
{
  Art,
  NaturalScience,
  History
}
