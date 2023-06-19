using CookBlog.Application.Abstractions;
using CookBlog.Application.DTO;

namespace CookBlog.Application.Queries;

public record GetCategories : IQuery<IEnumerable<CategoryDto>>;
