using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticleBlog.Core.Objects;
using ArticleBlog.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArticleBlog.Controllers
{
    //[Route("api/[controller]")]
    [Route("ArticleBlog/restapi/[controller]")]
    public class ArticlesController : Controller
    {
        ArticleBlogContext _context;

        public ArticlesController(ArticleBlogContext context) // => _context = context;
        {
            _context = context;

            if (_context.Articles.Count() == 0)
            {
                _context.Articles.Add(new Article { ID = 1, Title = "aaa", Content="denenw1", CreateDate=DateTime.Now, UserID=1 });
                _context.Articles.Add(new Article { ID = 2, Title = "bbb", Content="denenw1", CreateDate=DateTime.Now, UserID=1 });
                _context.Articles.Add(new Article { ID = 3, Title = "ccc", Content="denenw1", CreateDate=DateTime.Now, UserID=1 });
                _context.Articles.Add(new Article { ID = 4, Title = "ddd", Content="denenw1", CreateDate=DateTime.Now, UserID=1 });

                _context.SaveChanges();
            }
        }

        // GET: api/<controller>
        [HttpGet(Name = "GetArticles")]
        public IEnumerable<Article> Get()
        {
            return _context.Articles.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetArticle")]
        public IActionResult Get(int id)
        {
            var article = _context.Articles.FirstOrDefault(t => t.ID == id);
            if (article == null)
            {
                return NotFound();
            }
            return new ObjectResult(article);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Article newArticle)
        {
            if (newArticle == null)
                return BadRequest();

            _context.Articles.Add(newArticle);
            _context.SaveChanges();
            return CreatedAtRoute("GetArticle", new { id = newArticle.ID }, newArticle);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Article value)
        {
            var article = _context.Articles.FirstOrDefault(t => t.ID == id);
            if (article == null)
            {
                return NotFound();
            }

            _context.Articles.Update(article);
            _context.SaveChanges();
            return CreatedAtRoute("GetArticle", new { id = article.ID }, article);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var article = _context.Articles.FirstOrDefault(t => t.ID == id);
            if (article == null)
            {
                return NotFound();
            }

            _context.Articles.Remove(article);
            _context.SaveChanges();
            return CreatedAtRoute("GetArticles", new { });
        }
    }
}
