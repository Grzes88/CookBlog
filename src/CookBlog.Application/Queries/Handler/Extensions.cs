using CookBlog.Application.DTO;
using CookBlog.Core.Entities;

namespace CookBlog.Application.Queries.Handler;

public static class Extensions
{
    public static CategoryDto AsDto(this Category entity)
        => new()
        {
            FullName = entity.FullName,
            Posts = entity.Posts
        };
}
