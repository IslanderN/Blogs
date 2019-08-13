using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Services
{
    using Repository;
    using Models;

    public class CommentService
    {
        private readonly IGenericRepository<Comment> commentRepository;
        private readonly IGenericRepository<Blog> blogRepository;

        public CommentService(IGenericRepository<Comment> commenRepository, IGenericRepository<Blog> blogRepository)
        {
            this.commentRepository = commenRepository;
            this.blogRepository = blogRepository;
        }

        public List<Comment> GetAllCommentsToBlog(int blogId)
        {
            return this.commentRepository.GetQuery()
                .Where(c => c.BlogId == blogId)
                .ToList();
        }
        public bool AddComment(Comment comment)
        {
            if(this.blogRepository.Contains(comment.BlogId))
            {
                this.commentRepository.Create(comment);
                return true;
            }
            return false;
        }
        public void EditComment(Comment comment)
        {
            if (this.commentRepository.Contains(comment.CommentId))
            {
                this.commentRepository.Update(comment);
            }
        }
        public bool DeleteComment(int commentId)
        {
            if (this.commentRepository.Contains(commentId))
            {
                this.commentRepository.Delete(commentId);
                return true;
            }
            return false;
        }
    }
}
