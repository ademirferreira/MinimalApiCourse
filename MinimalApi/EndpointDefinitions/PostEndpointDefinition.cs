﻿using Application.Posts.Commands;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;
using MinimalApi.Abstractions;

namespace MinimalApi.EndpointDefinitions
{
    public class PostEndpointDefinition : IEndpointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            app.MapGet("/api/posts/{id}", async (IMediator mediator, int id) =>
            {
                var getPost = new GetPostById { PostId = id };
                var post = await mediator.Send(getPost);
                return Results.Ok(post);
            })
                .WithName("GetPostById");

            app.MapPost("/api/posts", async (IMediator mediator, Post post) =>
            {
                var createPost = new CreatePost { PostContent = post.Content };
                var createdPost = await mediator.Send(createPost);
                return Results.CreatedAtRoute("GetPostById", new { createdPost.Id }, createdPost);
            });

            app.MapGet("/api/posts", async (IMediator mediator) =>
            {
                var getPosts = new GetAllPosts();
                var posts = await mediator.Send(getPosts);
                return Results.Ok(posts);
            });

            app.MapPut("/api/posts/{id}", async (IMediator mediator, Post post, int id) =>
            {
                var updatePost = new UpdatePost { PostId = id, PostContent = post.Content };
                var updatedPost = await mediator.Send(updatePost);
                return Results.Ok(updatedPost);
            });

            app.MapDelete("/api/posts/{id}", async (IMediator mediator, int id) =>
            {
                var deletePost = new DeletePost { PostId = id };
                var deletedPost = await mediator.Send(deletePost);
                return Results.NoContent();
            });
        }
    }
}
