using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Services
{
    using Repository;
    using Models;

    public class BlogService
    {
        private readonly IGenericRepository<Blog> blogRepository;

        public BlogService(IGenericRepository<Blog> blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public List<Blog> GetAllBlogs()
        {
            return this.blogRepository.GetAll().ToList();
        }

        public Blog GetBlogById(int id)
        {
            return this.blogRepository.GetQuery()
                .FirstOrDefault(b => b.BlogId == id);
        }
        public void AddBlog(Blog blog)
        {
            this.blogRepository.Create(blog);
        }
        public void EditBlog(Blog blog)
        {
            if (this.blogRepository.Contains(blog.BlogId))
            {
                this.blogRepository.Update(blog);
            }
        }
        public void DeleteBlog(int blogId)
        {
            if (this.blogRepository.Contains(blogId))
            {
                this.blogRepository.Delete(blogId);
            }
        }
    }
}
