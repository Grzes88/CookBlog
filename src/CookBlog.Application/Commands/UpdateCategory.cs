using CookBlog.Application.Abstractions;

namespace CookBlog.Application.Commands;

public record UpdateCategory(Guid CategoryId, string FullName) : ICommand;
