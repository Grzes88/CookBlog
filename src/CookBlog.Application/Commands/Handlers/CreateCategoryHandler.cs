using CookBlog.Application.Abstractions;
using CookBlog.Core.Entities;
using CookBlog.Core.Repositories;

namespace CookBlog.Application.Commands.Handlers;

public sealed class CreateCategoryHandler : ICommandHandler<CreateCategory>
{
    private readonly ICategoryRepository _repository;

    public CreateCategoryHandler(ICategoryRepository repository)
        => _repository = repository;

    public async Task HandleAsync(CreateCategory command)
    {
        var category = Category.Create(command.FullName);

        await _repository.AddAsync(category);
    }
}
