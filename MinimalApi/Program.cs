using MinimalApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices();

var app = builder.Build();

app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception)
    {
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("An error ocurred");
    }
});

app.UseHttpsRedirection();

app.RegisterEndpointDefinitions();

app.Run();