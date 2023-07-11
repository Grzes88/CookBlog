using CookBlog.Application.Abstractions;
using CookBlog.Application.Exceptions;
using CookBlog.Core.Repositories;
using CookBlog.Core.ValuesObjects;

namespace CookBlog.Application.Commands.Handlers;

public sealed class UpdatePostHandler : ICommandHandler<UpdatePost>
{
    private readonly IPostRepository _postRepository;
    private readonly ITagRepository _tagRepository;

    public UpdatePostHandler(IPostRepository postRepository, ITagRepository tagRepository)
    {

        _postRepository = postRepository;
        _tagRepository = tagRepository;
    }

    public async Task HandleAsync(UpdatePost command)
    {
        var postId = new PostId(command.PostId);
        var post = await _postRepository.GetAsync(postId);

        if (post is null)
        {
            throw new NotFoundPostException(postId);
        }

        var tags = await _tagRepository.GetTags(command.Tags);

        post.Update(command.Title, command.Description, command.CategoryId, tags.ToHashSet());
    }
}
