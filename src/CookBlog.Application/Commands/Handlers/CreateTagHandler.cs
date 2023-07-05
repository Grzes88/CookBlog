using CookBlog.Application.Abstractions;
using CookBlog.Core.Entities;
using CookBlog.Core.Repositories;

namespace CookBlog.Application.Commands.Handlers;

public sealed class CreateTagHandler : ICommandHandler<CreateTag>
{
    private readonly ITagRepository _tagRepository;

    public CreateTagHandler(ITagRepository tagRepository)
        => _tagRepository = tagRepository;

    public async Task HandleAsync(CreateTag command)
    {
        var tag = Tag.Create(command.Description);

        await _tagRepository.AddAsync(tag);
    }
}
