using CookBlog.Application.Abstractions;
using CookBlog.Application.DTO;

namespace CookBlog.Application.Queries;

public record GetCategory(Guid CategoryId) : IQuery<CategoryDto>;



