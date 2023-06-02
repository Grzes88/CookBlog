using CookBlog.Application.Abstractions;
using CookBlog.Application.DTO;

namespace CookBlog.Application.Queries;

public class GetUser : IQuery<UserDto>
{
    public Guid UserId { get; set; }
}
