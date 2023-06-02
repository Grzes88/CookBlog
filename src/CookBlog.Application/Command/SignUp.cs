
using CookBlog.Application.Abstractions;

namespace CookBlog.Application.Command;

public record SignUp(Guid UserId, string Email, string Username, string Password, string FullName, string Role) : ICommand;
