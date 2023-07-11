using CookBlog.Application.Abstractions;
using CookBlog.Application.Exceptions;
using CookBlog.Core.Entities;
using CookBlog.Core.Repositories;
using CookBlog.Core.ValuesObjects;

namespace CookBlog.Application.Commands.Handlers;

public sealed class CreateCommentHandler : ICommandHandler<CreateComment>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IPostRepository _postRepository;

    public CreateCommentHandler(ICommentRepository commentRepository,
        IPostRepository postRepository)
    {
        _commentRepository = commentRepository;
        _postRepository = postRepository;
    }

    public async Task HandleAsync(CreateComment command)
    {
        var postId = new PostId(command.PostId);
        var post = await _postRepository.AnyAsync(postId);

        if (post is false)
        {
            throw new NotFoundPostException(postId);
        }

        var comment = Comment.Create(command.FullName, command.Description, command.PostId);

        await _commentRepository.AddAsync(comment);
    }
}
