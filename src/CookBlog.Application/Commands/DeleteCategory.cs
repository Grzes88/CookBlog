using CookBlog.Application.Abstractions;

namespace CookBlog.Application.Commands;

public record DeleteCategory(Guid CategoryId) : ICommand;
