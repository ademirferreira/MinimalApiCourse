using Application.Abstractions;
using Data;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<SocialDbContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddScoped<IPostRepository, PostRepository>();
var app = builder.Build();


app.UseHttpsRedirection();


app.Run();


