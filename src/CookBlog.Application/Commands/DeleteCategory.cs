using CookBlog.Application.Abstractions;

namespace CookBlog.Application.Commands;

public sealed record DeleteCategory(Guid CategoryId) : ICommand;
