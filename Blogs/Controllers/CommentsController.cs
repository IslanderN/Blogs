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
    public class CommentsController : ControllerBase
    {
        private readonly CommentService commentService;

        public CommentsController(CommentService commentService)
        {
            this.commentService = commentService;
        }

        [ResponseCache(Duration = 300)]
        [HttpGet("[action]")]
        public IEnumerable<Comment> GetCommentsForBlogPost(int blogPostId)
        {
            return this.commentService.GetAllCommentsToBlog(blogPostId);
        }

        [HttpPost("[action]")]
        public IActionResult AddComment([FromBody]Comment comment)
        {
            if (this.commentService.AddComment(comment))
            {
                return this.Ok();
            }
            return this.BadRequest("Blog isn't found");
        }

        [HttpGet("[action]")]
        public IActionResult DeleteComment(int commentId)
        {
            if (this.commentService.DeleteComment(commentId))
            {
                return this.Ok();
            }
            return this.BadRequest("Comment isn't found");
        }
        [HttpPost("[action]")]
        public IActionResult EditComment([FromBody]Comment comment)
        {
            try
            {
                this.commentService.EditComment(comment);
            }
            catch (Exception ex)
            {
                //logger.LogError(ex);
                return this.BadRequest();
            }
            return this.Ok();
        }
    }
}