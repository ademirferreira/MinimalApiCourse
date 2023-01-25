using Application.Abstractions;
using Application.Posts.Commands;
using Data.Repositories;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MinimalApi.Extensions
{
    public static class MinimalApiExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<SocialDbContext>(opt => opt.UseSqlServer(connectionString));
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddMediatR(typeof(CreatePost));
        }
    }
}
