using CookBlog.Application.Abstractions;
using CookBlog.Application.Exceptions;
using CookBlog.Core.Repositories;
using CookBlog.Core.ValuesObjects;

namespace CookBlog.Application.Commands.Handlers;

public sealed class DeletePostHandler : ICommandHandler<DeletePost>
{
    private readonly IPostRepository _postRepository;

    public DeletePostHandler(IPostRepository postRepository) 
        => _postRepository = postRepository;

    public async Task HandleAsync(DeletePost command)
    {
        var postId = new PostId(command.PostId);
        var post = await _postRepository.GetAsync(postId);

        if (post is null)
        {
            throw new NotFoundPostException(postId);
        }

        _postRepository.DeleteAsync(post);
    }
}
