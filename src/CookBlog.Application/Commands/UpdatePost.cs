using CookBlog.Application.Abstractions;

namespace CookBlog.Application.Commands;

public sealed record UpdatePost(Guid PostId, string Title,
    string Description, Guid CategoryId, ICollection<Guid> Tags) : ICommand;


