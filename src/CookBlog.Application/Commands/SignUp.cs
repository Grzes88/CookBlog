
using CookBlog.Application.Abstractions;

namespace CookBlog.Application.Commands;

public record SignUp(Guid UserId, string Email, string UserName, string Password, string FullName, string Role) : ICommand;
