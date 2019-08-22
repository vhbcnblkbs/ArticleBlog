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
    public class UsersController : Controller
    {
        private readonly ArticleBlogContext _context;

        public UsersController(ArticleBlogContext context) // => _context = context;
        {
            _context = context;

            if (_context.Users.Count() == 0)
            {
                _context.Users.Add(new User { ID = 1, Name="ali", Surname = "soy", Email="aaa@hotmail.com",BirthDate=DateTime.Now.AddYears(-26), Gentle=true,Password="123", CreateDate = DateTime.Now });
                _context.Users.Add(new User { ID = 2, Name="veli", Surname = "soy1", Email="bbb@gmail.com",BirthDate=DateTime.Now.AddYears(-15), Gentle=true,Password="456", CreateDate = DateTime.Now });
                _context.Users.Add(new User { ID = 3, Name="deli", Surname = "soy2", Email="ccc@yahoo.com",BirthDate=DateTime.Now.AddYears(-34), Gentle=true,Password="789", CreateDate = DateTime.Now });

                _context.SaveChanges();
            }
        }

        // GET: api/<controller>
        [HttpGet(Name="GetUsers")]
        public IEnumerable<User> Get()
        {
            return _context.Users.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name="GetUser")]
        public IActionResult Get(int id)
        {
            var user = _context.Users.FirstOrDefault(t => t.ID == id);
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]User newUser)
        {
            if (newUser == null)
                return BadRequest();

            _context.Users.Add(newUser);
            _context.SaveChanges();
            return CreatedAtRoute("GetUser", new { id = newUser.ID }, newUser);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            var user = _context.Users.FirstOrDefault(t => t.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Update(user);
            _context.SaveChanges();
            return CreatedAtRoute("GetUser", new { id = user.ID }, user);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(t => t.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return CreatedAtRoute("GetUsers", new { });
        }
    }
}
