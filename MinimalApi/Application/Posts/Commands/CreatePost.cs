using Domain.Models;
using MediatR;

namespace Application.Posts.Commands
{
    public class CreatePost : IRequest<Post>
    {
        public string? PostContent { get; set; }

    }
}
