using CookBlog.Application.Abstractions;
using CookBlog.Core.ValuesObjects;

namespace CookBlog.Application.Commands;

public sealed record CreateCategory(Guid CategoryId, FullName FullName) : ICommand;

