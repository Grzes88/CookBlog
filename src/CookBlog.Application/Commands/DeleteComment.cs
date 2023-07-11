using CookBlog.Application.Abstractions;

namespace CookBlog.Application.Commands;

public sealed record DeleteComment(Guid CommentId) : ICommand;