using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Context
{
    using Models;

    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Key>().HasData(
                new Key
                {
                    KeyId = 1,
                    KeyGUID = Guid.NewGuid()
                });
            modelBuilder.Entity<Blog>();
            modelBuilder.Entity<Comment>();
            modelBuilder.Entity<User>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
