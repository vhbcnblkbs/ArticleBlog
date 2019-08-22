using ArticleBlog.Core.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleBlog.Models
{
    public class ArticleBlogContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }

        public ArticleBlogContext(DbContextOptions<ArticleBlogContext> options) : base(options)
        {
        }
    }
}
