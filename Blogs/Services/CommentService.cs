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

        public CommentService(IGenericRepository<Comment> commenRepository)
        {
            this.commentRepository = commenRepository;
        }

        public List<Comment> GetAllCommentsToBlog(int blogId)
        {
            return this.commentRepository.GetQuery()
                .Where(c => c.BlogId == blogId)
                .ToList();
        }
        public void AddComment(Comment comment)
        {
            this.commentRepository.Create(comment);
        }
        public void EditComment(Comment comment)
        {
            if (this.commentRepository.Contains(comment.CommentId))
            {
                this.commentRepository.Update(comment);
            }
        }
        public void DeleteComment(int commentId)
        {
            if (this.commentRepository.Contains(commentId))
            {
                this.commentRepository.Delete(commentId);
            }
        }
    }
}
