using Application.Abstractions;
using Application.Posts.Commands;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Posts.CommandHandlers
{
    public class UpdatePostHandler : IRequestHandler<UpdatePost, Post>
    {
        private readonly IPostRepository _repository;

        public UpdatePostHandler(IPostRepository repository)
        {
            _repository = repository;
        }
        public async Task<Post> Handle(UpdatePost request, CancellationToken cancellationToken)
        {
            return await _repository.UpdatePost(request.PostContent, request.PostId);
        }
    }
}
