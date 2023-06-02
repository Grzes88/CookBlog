using CookBlog.Application.DTO;

namespace CookBlog.Application.Security;

public interface IAuthenticator
{
    JwtDto CreateToken(Guid userId, string role);
}
