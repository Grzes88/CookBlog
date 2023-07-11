using CookBlog.Core.Exceptions;

namespace CookBlog.Application.Exceptions;

public class InvalidCredentialsException : CustomException
{
    public InvalidCredentialsException() : base("Invalid credentials.")
    {   
    }
}
