using CookBlog.Core.Exceptions;

namespace CookBlog.Application.Exceptions;

public sealed class UserNameAlreadyInUseException : CustomException
{
    public string UserName { get; }

    public UserNameAlreadyInUseException(string userName) : base($"UserName: '{userName}' is already in use.")
    {
        UserName = userName;
    }
}
