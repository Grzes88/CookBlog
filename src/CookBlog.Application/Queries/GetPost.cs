using CookBlog.Application.Abstractions;
using CookBlog.Application.DTO;

namespace CookBlog.Application.Queries;

public record GetPost(Guid PostId) : IQuery<PostDto>; 

