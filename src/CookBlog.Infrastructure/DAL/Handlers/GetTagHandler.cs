using CookBlog.Application.Abstractions;
using CookBlog.Application.DTO;
using CookBlog.Application.Exceptions;
using CookBlog.Application.Queries;
using CookBlog.Core.Repositories;
using CookBlog.Core.ValuesObjects;

namespace CookBlog.Infrastructure.DAL.Handlers;

public sealed class GetTagHandler : IQueryHandler<GetTag, TagDto>
{
    private readonly ITagRepository _tagRepository;

    public GetTagHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<TagDto> HandleAsync(GetTag query)
    {
        var tagId = new TagId(query.TagId);
        var tag = await _tagRepository.GetAsync(tagId);
        if (tag is null)
        {
            throw new NotFoundTagException();
        }

        return new TagDto { Id = tag.Id, Description = tag.Description };
    }
}