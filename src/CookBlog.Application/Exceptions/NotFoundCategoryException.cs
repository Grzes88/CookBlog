using CookBlog.Core.Exceptions;

namespace CookBlog.Application.Exceptions;

public class NotFoundCategoryException : CustomException
{
    public NotFoundCategoryException(Guid id) : base($"Category with ID: {id} was not found.") 
        => Id = id;

    public Guid Id { get; }
}
