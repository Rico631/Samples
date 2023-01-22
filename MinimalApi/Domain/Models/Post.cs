using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
