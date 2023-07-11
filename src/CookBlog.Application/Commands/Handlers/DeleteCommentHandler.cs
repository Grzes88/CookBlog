using CookBlog.Application.Abstractions;
using CookBlog.Application.Exceptions;
using CookBlog.Core.Repositories;
using CookBlog.Core.ValuesObjects;

namespace CookBlog.Application.Commands.Handlers;

public sealed class DeleteCommentHandler : ICommandHandler<DeleteComment>
{
    private readonly ICommentRepository _commentRepository;

    public DeleteCommentHandler(ICommentRepository commentRepository) 
        => _commentRepository = commentRepository;

    public async Task HandleAsync(DeleteComment command)
    {
        var commentId = new CommentId(command.CommentId);
        var comment = await _commentRepository.GetAsync(commentId);

        if (comment is null) 
        {
            throw new NotFoundCommentException(commentId);
        }

        _commentRepository.DeleteAsync(comment);
    }
}
