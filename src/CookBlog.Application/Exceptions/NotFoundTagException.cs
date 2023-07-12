using CookBlog.Core.Exceptions;

namespace CookBlog.Application.Exceptions;

public class NotFoundTagException : CustomException
{
    public NotFoundTagException(Guid id) : base($"Tag with ID: {id} was not found.") 
        => Id = id;                       

    public Guid Id { get; }
}
