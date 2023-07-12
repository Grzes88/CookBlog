using CookBlog.Application.Abstractions;

namespace CookBlog.Application.Commands;

public sealed record CreateComment(string FullName, string Description, Guid PostId) : ICommand; 
