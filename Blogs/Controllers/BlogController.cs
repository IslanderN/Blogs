using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blogs.Controllers
{
    using Services;
    using Models;

    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogService blogService;

        public BlogController(BlogService blogService)
        {
            this.blogService = blogService;
        }

        // GET: api/Blog
        [HttpGet]
        public IEnumerable<Blog> Get()
        {
            return this.blogService.GetAllBlogs();
        }

        // GET: api/Blog/5
        [HttpGet("{id}", Name = "Get")]
        public Blog Get(int id)
        {
            return this.blogService.GetBlogById(id);
        }

        // POST: api/Blog
        [HttpPost]
        public void Post([FromBody] Blog value)
        {
            this.blogService.EditBlog(value);
        }
        

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.blogService.DeleteBlog(id);
        }
    }
}
