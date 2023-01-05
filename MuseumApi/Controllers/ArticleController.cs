using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuseumApi.DAL;
using MuseumApi.Models;
using MuseumApi.Services;

namespace MuseumApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ArticleController : ControllerBase
  {
    private readonly IUnitOfWork _repositories;

    public ArticleController(IUnitOfWork unitOfWork)
    {
      _repositories = unitOfWork;
    }

    // GET: api/Article
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Article>>> Getarticles()
    {
      return await _repositories.Articles.FindAll();
    }

    // GET: api/Article/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Article>> GetArticle(Guid id)
    {
      var article = await _repositories.Articles.Find(id);

      if (article == null)
      {
        return NotFound();
      }

      return article;
    }

    [HttpGet("museum/{museumID}")]
    public async Task<ActionResult<IEnumerable<Article>>> GetArticlesFromMuseum(Guid museumID)
    {
      var articles = await _repositories.Articles.FindBy(article => article.MuseumID == museumID);

      return articles;
    }

    // PUT: api/Article/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut]
    public async Task<IActionResult> PutArticle(Article article)
    {
      try
      {
        await _repositories.Articles.UpdateAsync(article);
      }
      catch (DbUpdateConcurrencyException)
      {
        throw;
      }

      return NoContent();
    }

    // POST: api/Article
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Article>> PostArticle(Article article)
    {
      await _repositories.Articles.CreateAsync(article);

      return CreatedAtAction("GetArticle", new { id = article.ArticleID }, article);
    }

    // DELETE: api/Article/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArticle(Guid id)
    {
      var article = await _repositories.Articles.Find(id);
      if (article == null)
      {
        return NotFound();
      }

      await _repositories.Articles.DeleteAsync(article);

      return NoContent();
    }
  }
}
