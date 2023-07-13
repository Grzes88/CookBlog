using CookBlog.Core.Exceptions;

namespace CookBlog.Application.Exceptions;

public class NotFoundTagException : CustomException
{
    public NotFoundTagException() : base($"Tag was not found.")
    {
    }            
}
