using CookBlog.Application.Abstractions;
using CookBlog.Application.Commands;
using CookBlog.Application.DTO;
using CookBlog.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CookBlog.Controllers;

[ApiController]
//[Authorize]
public class TagController : ControllerBase
{
    private readonly ICommandHandler<CreateTag> _createTagHandler;
    private readonly IQueryHandler<GetTag, TagDto> _getTagHandler;
    private readonly ICommandHandler<DeleteTag> _deleteTagHandler;
    private readonly IQueryHandler<GetTags, IEnumerable<TagDto>> _getTagsHandler;
    private readonly ICommandHandler<UpdateTag> _updateTagHandler;

    public TagController(ICommandHandler<CreateTag> createTagHandler,
        IQueryHandler<GetTag, TagDto> getTagHandler, ICommandHandler<DeleteTag> deleteTagHandler,
        IQueryHandler<GetTags, IEnumerable<TagDto>> getTagsHandler, ICommandHandler<UpdateTag> updateTagHandler)
    {
        _createTagHandler = createTagHandler;
        _getTagHandler = getTagHandler;
        _deleteTagHandler = deleteTagHandler;
        _getTagsHandler = getTagsHandler;
        _updateTagHandler = updateTagHandler;
    }

    [HttpPost("tag")]
    public async Task<ActionResult> Post(CreateTag command)
    {
        await _createTagHandler.HandleAsync(command);
        return NoContent();
    }

    [HttpGet("tag/{tagId}")]
    public async Task<ActionResult<TagDto>> GetId(Guid tagId)
    {
        var tag = await _getTagHandler.HandleAsync(new GetTag(tagId));
        return Ok(tag);
    }

    [HttpDelete("tag/{tagId}")]
    public async Task<ActionResult> Delete(Guid tagId)
    {
        await _deleteTagHandler.HandleAsync(new DeleteTag(tagId));
        return NoContent();
    }

    [HttpGet("tags")]
    public async Task<ActionResult<IEnumerable<TagDto>>> GetAll([FromQuery] GetTags query)
    {
        var tags = await _getTagsHandler.HandleAsync(query);
        return Ok(tags);
    }

    [HttpPut("tag/{tagId}")]
    public async Task<ActionResult> Put(Guid tagId, UpdateTag command)
    {
        await _updateTagHandler.HandleAsync(command with { TagId = tagId });
        return NoContent();
    }
}