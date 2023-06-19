using CookBlog.Core.Entities;

namespace CookBlog.Application.DTO;

public class CategoryDto
{
    public string? FullName { get; set; }
    public IEnumerable<Post>? Posts { get; set; }
}
