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
    using Fiters;

    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(AuthorizationFilter))]
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
        public IActionResult Post([FromBody] Blog value)
        {
            if(!ModelState.IsValid)
            {
                return this.BadRequest("Model is invalid");
            }
            this.blogService.AddOrUpdate(value);

            return this.Ok();
        }
        

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           
            if (this.blogService.DeleteBlog(id))
            {
                return this.Ok();
            }
            else
            {
                return this.BadRequest("Blog isn't found");
            }
        }

    }
}
