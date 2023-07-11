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
    
    public static PostDto AsDto(this Post entity) => new PostDto()
    {
        Id = entity.Id,
        Title = entity.Title,
        Description = entity.Description,
        Tags = entity.Tags.Select(t => new TagDto { Id = t.Id, Description = t.Description }).ToHashSet(),
        Comments = entity.Comments.Select(c => new CommentDto { Id = c.Id, FullName = c.FullName, Description = c.Description }).ToHashSet(),
        Category = entity.Category.AsDto()
    };

    public static UserDto AsDto(this User entity) => new UserDto()
    {
        Id = entity.Id,
        UserName = entity.UserName,
        FullName = entity.FullName
    };
}
