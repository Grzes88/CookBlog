using CookBlog.Application.Abstractions;

namespace CookBlog.Application.Commands;

public sealed record UpdateComment(Guid CommentId, string FullName, string Description) : ICommand;
