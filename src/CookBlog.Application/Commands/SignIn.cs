using CookBlog.Application.Abstractions;

namespace CookBlog.Application.Commands;

public record SignIn(string Email, string Password) : ICommand;
