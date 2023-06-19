using CookBlog.Application.Abstractions;
using CookBlog.Application.Exceptions;
using CookBlog.Core.Repositories;
using CookBlog.Core.ValuesObjects;

namespace CookBlog.Application.Commands.Handlers;

public sealed class CreateCategoryHandler : ICommandHandler<CreateCategory>
{
    private readonly ICategoryRepository _repository;

    public CreateCategoryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(CreateCategory command)
    {
        var categoryId = new CategoryId(command.CategoryId);
        var category = await _repository.GetAsync(categoryId);

        if (category is null)
        {
            throw new CategoryNotFoundException();
        }

        await _repository.AddAsync(category);
    }
}
