using Application.Posts.Commands;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Abstractions;
using MinimalApi.Filters;
using System.Reflection.Metadata;

namespace MinimalApi.EndpointDefinitions
{
    public class PostEndpointDefinition : IEndpointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var posts = app.MapGroup("/api/posts");

            posts.MapGet("/{id}", GetPostById).WithName(nameof(GetPostById));
            posts.MapPost("/", CreatePost).WithName(nameof(CreatePost)).AddEndpointFilter<PostValidationFilter>();
            posts.MapGet("/", GetAllPosts).WithName(nameof(GetAllPosts));
            posts.MapPut("/{id}", UpdatePost).WithName(nameof(UpdatePost));
            posts.MapDelete("/{id}", DeletePost).WithName(nameof(DeletePost));
        }

        private async Task<IResult> GetPostById(IMediator mediator, int id)
        {
            var result = await mediator.Send(new GetPostById { Id = id });
            return TypedResults.Ok(result);
        }

        private async Task<IResult> CreatePost(IMediator mediator, CreatePost post)
        {
            var result = await mediator.Send(post);
            return Results.CreatedAtRoute(nameof(GetPostById), new { result.Id }, result);
        }

        private async Task<IResult> GetAllPosts(IMediator mediator)
        {
            return TypedResults.Ok(await mediator.Send(new GetAllPosts()));
        }

        private async Task<IResult> UpdatePost(IMediator mediator, int id, Post post)
        {
            return TypedResults.Ok(await mediator.Send(new UpdatePost { PostId = id, PostContent = post.Content }));
        }

        private async Task<IResult> DeletePost(IMediator mediator, int id)
        {
            await mediator.Send(new DeletePost { PostId = id });
            return TypedResults.NoContent();
        }
    }
}
