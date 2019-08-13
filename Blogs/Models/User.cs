using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Models
{
    public class User
    {
        public int UserId { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}
