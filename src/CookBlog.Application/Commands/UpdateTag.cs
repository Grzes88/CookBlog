using CookBlog.Application.Abstractions;

namespace CookBlog.Application.Commands;

public sealed record UpdateTag(Guid TagId, string Description) : ICommand;

