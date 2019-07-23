using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string Content { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public DateTime CreateTime { get; set; }

        [ForeignKey("Blog")]
        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
