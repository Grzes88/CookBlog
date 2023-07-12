using CookBlog.Application.Abstractions;

namespace CookBlog.Application.Commands;

public sealed record DeletePost(Guid PostId) : ICommand; 
