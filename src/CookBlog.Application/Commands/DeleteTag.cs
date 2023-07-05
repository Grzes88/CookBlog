using CookBlog.Application.Abstractions;

namespace CookBlog.Application.Commands;

public sealed record DeleteTag(Guid TagId) : ICommand;
