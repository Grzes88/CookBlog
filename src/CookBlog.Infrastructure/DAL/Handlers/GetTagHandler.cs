using CookBlog.Application.Abstractions;
using CookBlog.Application.DTO;
using CookBlog.Application.Queries;
using CookBlog.Core.Repositories;

namespace CookBlog.Infrastructure.DAL.Handlers;

public sealed class GetTagHandler : IQueryHandler<GetTag, TagDto>
{
    private readonly ITagRepository _tagRepository;

    public GetTagHandler(ITagRepository tagRepository) 
        => _tagRepository = tagRepository;

    public async Task<TagDto> HandleAsync(GetTag query)
    {
        var tag = await _tagRepository.GetByIdForRedisAsync(query.TagId);

        return new TagDto { Id = tag.Id, Description = tag.Description };
    }
}