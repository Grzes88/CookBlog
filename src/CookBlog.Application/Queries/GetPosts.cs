using CookBlog.Application.Abstractions;
using CookBlog.Application.DTO;

namespace CookBlog.Application.Queries;

public record GetPosts() : IQuery<IEnumerable<PostDto>>;
