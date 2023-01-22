using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Posts.Commands
{
    public class UpdatePost : IRequest<Post>
    {
        public int PostId { get; set; }
        public string? PostContent { get; set; }
    }
}
