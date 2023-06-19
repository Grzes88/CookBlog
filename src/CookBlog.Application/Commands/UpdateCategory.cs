using CookBlog.Application.Abstractions;
using CookBlog.Core.ValuesObjects;

namespace CookBlog.Application.Commands;

public record UpdateCategory(Guid CategoryId, FullName FullName) : ICommand;
