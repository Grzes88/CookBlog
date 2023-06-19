using CookBlog.Core.Exceptions;

namespace CookBlog.Application.Exceptions;

internal class CategoryNotFoundException : CustomException
{
    public Guid Id { get; }

    public CategoryNotFoundException() 
        : base($"Category with ID was not found.")
    {
    }

    public CategoryNotFoundException(Guid id) 
        : base($"Category with ID: {id} was not found.")
    {
    }
}
