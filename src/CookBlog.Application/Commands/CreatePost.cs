using CookBlog.Application.Abstractions;

namespace CookBlog.Application.Commands;

public sealed record CreatePost(string Title, string Description,
    Guid CategoryId, Guid UserId, ICollection<Guid> Tags) : ICommand;

