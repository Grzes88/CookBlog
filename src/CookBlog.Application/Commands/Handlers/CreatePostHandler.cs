using CookBlog.Application.Abstractions;
using CookBlog.Core.Entities;
using CookBlog.Core.Repositories;

namespace CookBlog.Application.Commands.Handlers;

public sealed class CreatePostHandler : ICommandHandler<CreatePost>
{
    private readonly IPostRepository _postRepository;
    private readonly ITagRepository _tagRepository;

    public CreatePostHandler(IPostRepository postRepository,
        ITagRepository tagRepository)
    {
        _postRepository = postRepository;
        _tagRepository = tagRepository;
    }

    public async Task HandleAsync(CreatePost command)
    {
        var tags = await _tagRepository.GetTags(command.Tags);

        var post = Post.Create(command.Title, command.Description, command.CategoryId, command.UserId, tags.ToHashSet());

        await _postRepository.AddAsync(post);
    }
}
