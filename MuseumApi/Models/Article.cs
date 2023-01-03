using System;

namespace MuseumApi.Models
{
  public class Article
  {
    public Guid ArticleID { get; set; }

    public string Name { get; set; }

    public Boolean Damaged { get; set; } = false;

    public Guid MuseumID { get; set; }

    public virtual Museum Museum { get; set; }
  }
}
