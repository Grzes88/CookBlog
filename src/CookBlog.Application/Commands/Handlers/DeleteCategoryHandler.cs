using CookBlog.Application.Abstractions;
using CookBlog.Application.Exceptions;
using CookBlog.Core.Repositories;

namespace CookBlog.Application.Commands.Handlers;

public class DeleteCategoryHandler : ICommandHandler<DeleteCategory>
{
    private readonly ICategoryRepository _repository;

    public DeleteCategoryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(DeleteCategory command)
    {
        var categoryId = command.CategoryId;

        if (Guid.Empty == categoryId)
        {
            throw new CategoryNotFoundException();
        }

        await _repository.DeleteAsync(categoryId);
    }
}
