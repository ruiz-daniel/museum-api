using System;

namespace MuseumApi.Models
{
  public class Museum
  {
    public string id { get; set; }

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
