using CookBlog.Application.Abstractions;
using CookBlog.Application.Exceptions;
using CookBlog.Core.Repositories;
using CookBlog.Core.ValuesObjects;

namespace CookBlog.Application.Commands.Handlers;

public sealed class UpdateCategoryHandler : ICommandHandler<UpdateCategory>
{
    private readonly ICategoryRepository _repository;

    public UpdateCategoryHandler(ICategoryRepository repository)
        => _repository = repository;

    public async Task HandleAsync(UpdateCategory command)
    {
        var categoryId = new CategoryId(command.CategoryId);
        var category = await _repository.GetAsync(categoryId);

        if (category is null) 
        {
            throw new NotFoundCategoryException(categoryId);
        }

        category.Update(command.FullName);
    }
}
