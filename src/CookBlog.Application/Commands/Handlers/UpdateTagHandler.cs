using CookBlog.Application.Abstractions;
using CookBlog.Core.Repositories;
using CookBlog.Core.ValuesObjects;

namespace CookBlog.Application.Commands.Handlers;

public sealed class UpdateTagHandler : ICommandHandler<UpdateTag>
{
    private readonly ITagRepository _tagRepository;

    public UpdateTagHandler(ITagRepository tagRepository) 
        => _tagRepository = tagRepository;

    public async Task HandleAsync(UpdateTag command)
    {
        var tagId = new TagId(command.TagId);
        var tag = await _tagRepository.GetAsync(tagId);

        if (tag is null)
        {
            throw new Exception($"tag not found");
        }

        tag.Update(command.Description);
    }
}
