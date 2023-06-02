using CookBlog.Application.Abstractions;
using CookBlog.Application.Command;
using CookBlog.Application.DTO;
using CookBlog.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CookBlog;

public static class UsersApi
{
    private const string MeRoute = "me";

    public static WebApplication UseUsersApi(this WebApplication app)
    {
        app.MapGet("api/users/me", async ([FromServices] HttpContext context, [FromServices] IQueryHandler<GetUser, UserDto> handler) =>
        {
            var userDto = await handler.HandleAsync(new GetUser { UserId = Guid.Parse(context.User.Identity.Name) });
            return Results.Ok(userDto);
        }).RequireAuthorization().WithName(MeRoute);

        app.MapGet("api/users/{userId:guid}", async (Guid userId, [FromServices] IQueryHandler<GetUser, UserDto> handler) =>
        {
            var userDto = await handler.HandleAsync(new GetUser { UserId = userId });
            return userDto is null ? Results.NotFound() : Results.Ok(userDto);
        }).RequireAuthorization("is-admin");

        app.MapPost("api/users", async ([FromBody] SignUp command, [FromServices] ICommandHandler<SignUp> handler) =>
        {
            command = command with { UserId = Guid.NewGuid() };
            await handler.HandleAsync(command);
            return Results.CreatedAtRoute(MeRoute);
        });

        return app;
    }
}
