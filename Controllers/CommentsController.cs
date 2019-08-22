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
    public class CommentsController : Controller
    {
        ArticleBlogContext _context;

        public CommentsController(ArticleBlogContext context) // => _context = context;
        {
            _context = context;

            if (_context.Comments.Count() == 0)
            {
                _context.Comments.Add(new Comment { ID = 1, ArticleID=1, Content = "comm1", CreateDate = DateTime.Now, UserID = 1 });
                _context.Comments.Add(new Comment { ID = 2, ArticleID=1, Content = "comm2", CreateDate = DateTime.Now, UserID = 1 });
                _context.Comments.Add(new Comment { ID = 3, ArticleID=2, Content = "comm3", CreateDate = DateTime.Now, UserID = 1 });
                _context.Comments.Add(new Comment { ID = 4, ArticleID=4, Content = "comm14", CreateDate = DateTime.Now, UserID = 1 });

                _context.SaveChanges();
            }
        }

        // GET: api/<controller>
        [HttpGet(Name = "GetComments")]
        public IEnumerable<Comment> Get()
        {
            return _context.Comments.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetComment")]
        public IActionResult Get(int id)
        {
            var comment = _context.Comments.FirstOrDefault(t => t.ID == id);
            if (comment == null)
            {
                return NotFound();
            }
            return new ObjectResult(comment);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Comment newComment)
        {
            if (newComment == null)
                return BadRequest();

            _context.Comments.Add(newComment);
            _context.SaveChanges();
            return CreatedAtRoute("GetComment", new { id = newComment.ID }, newComment);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Comment value)
        {
            var comment = _context.Comments.FirstOrDefault(t => t.ID == id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Update(comment);
            _context.SaveChanges();
            return CreatedAtRoute("GetComment", new { id = comment.ID }, comment);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var comment = _context.Comments.FirstOrDefault(t => t.ID == id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return CreatedAtRoute("GetComments", new { });
        }
    }
}
