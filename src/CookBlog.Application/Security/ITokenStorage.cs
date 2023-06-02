using CookBlog.Application.DTO;

namespace CookBlog.Application.Security;

public interface ITokenStorage
{
    void Set(JwtDto jwt);
    JwtDto Get();
}
