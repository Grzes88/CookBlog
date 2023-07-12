using CookBlog.Application.Abstractions;
using CookBlog.Application.Exceptions;
using CookBlog.Core.Repositories;
using CookBlog.Core.ValuesObjects;

namespace CookBlog.Application.Commands.Handlers;

public sealed class DeleteCategoryHandler : ICommandHandler<DeleteCategory>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryHandler(ICategoryRepository categoryRepository) 
        => _categoryRepository = categoryRepository;

    public async Task HandleAsync(DeleteCategory command)
    {
        var categoryId = new CategoryId(command.CategoryId);
        var category = await _categoryRepository.GetAsync(categoryId);

        if (category is null)
        {
            throw new NotFoundCategoryException(categoryId);
        }

        _categoryRepository.DeleteAsync(category);
    }
}
