using CookBlog.Application.Abstractions;

namespace CookBlog.Application.Commands;

public sealed record CreateTag(string Description) : ICommand;