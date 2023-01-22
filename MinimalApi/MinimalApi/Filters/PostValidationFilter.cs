using Application.Posts.Commands;
using Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace MinimalApi.Filters
{
    public class PostValidationFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var post = context.GetArgument<CreatePost>(1);
            if (string.IsNullOrWhiteSpace(post.PostContent))
                return await Task.FromResult(Results.BadRequest("PostContent must be not empty."));

            return await next(context);
        }
    }
}
