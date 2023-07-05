using CookBlog.Application.Abstractions;
using CookBlog.Application.DTO;

namespace CookBlog.Application.Queries;

public record GetTags() : IQuery<IEnumerable<TagDto>>;
