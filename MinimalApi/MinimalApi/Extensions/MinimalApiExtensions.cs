using Application.Abstractions;
using Application.Posts.Commands;
using DataAccess;
using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Abstractions;

namespace MinimalApi.Extensions
{
    public static class MinimalApiExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            var cs = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<SocialDbContext>(opt => opt.UseSqlServer(cs));
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddMediatR(typeof(CreatePost));
        }

        public static void RegisterEndpointDefinitions(this WebApplication app)
        {
            var endpoints = typeof(Program).Assembly
                .GetTypes()
                .Where(x => x.IsAssignableTo(typeof(IEndpointDefinition)) && !x.IsAbstract && !x.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IEndpointDefinition>();

            foreach(var endpoint in endpoints)
            {
                endpoint.RegisterEndpoints(app);
            }
        }
    }
}
