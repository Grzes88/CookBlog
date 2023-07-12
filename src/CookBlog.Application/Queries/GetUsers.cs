using CookBlog.Application.Abstractions;
using CookBlog.Application.DTO;

namespace CookBlog.Application.Queries;

public class GetUsers : IQuery<IEnumerable<UserDto>>
{
}
