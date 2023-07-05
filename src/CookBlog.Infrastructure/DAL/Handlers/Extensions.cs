using CookBlog.Application.DTO;
using CookBlog.Core.Entities;

namespace CookBlog.Infrastructure.DAL.Handlers;

public static class Extensions
{
    public static CategoryDto AsDto(this Category entity) => new CategoryDto()
    {
        Id = entity.Id,
        FullName = entity.FullName
    }; 
    
    public static TagDto AsDto(this Tag entity) => new TagDto()
    {
        Id = entity.Id,
        Description = entity.Description
    };
}

