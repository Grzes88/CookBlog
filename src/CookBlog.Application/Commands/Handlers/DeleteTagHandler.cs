using CookBlog.Application.Abstractions;
using CookBlog.Application.Exceptions;
using CookBlog.Core.Repositories;
using CookBlog.Core.ValuesObjects;

namespace CookBlog.Application.Commands.Handlers;

public sealed class DeleteTagHandler : ICommandHandler<DeleteTag>
{
    private readonly ITagRepository _tagRepository;

    public DeleteTagHandler(ITagRepository tagRepository) 
        => _tagRepository = tagRepository;

    public async Task HandleAsync(DeleteTag command)
    {
        var tagId = new TagId(command.TagId);
        var tag = await _tagRepository.GetAsync(tagId);

        if (tag is null)
        {
            throw new NotFoundTagException();
        }

        _tagRepository.DeleteAsync(tag);
    }
}
