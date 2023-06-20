using CookBlog.Application.Abstractions;
using CookBlog.Application.Commands;
using CookBlog.Application.DTO;
using CookBlog.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CookBlog.Controllers;

[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICommandHandler<CreateCategory> _createCategoryHandler;
    private readonly IMediator _mediator;

    public CategoryController(ICommandHandler<CreateCategory> CreateCategoryHandler, IMediator mediator)
    {
        _createCategoryHandler = CreateCategoryHandler;
        _mediator = mediator;
    }

    [HttpPost("category")]
    public async Task<ActionResult> Post(CreateCategory command)
    {
        await _createCategoryHandler.HandleAsync(command);
        return NoContent();
    }

    [HttpGet("category/{id}")]
    public async Task<ActionResult<CategoryDto>> GetId(Guid id, CancellationToken token)
    {
        var category = await _mediator.Send(new GetCategory(id), token);
        return Ok(category);
    }

    [HttpGet("api/categories")]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll(CancellationToken token)
    {
        var categories = await _mediator.Send(new GetCategories(), token);
        return Ok(categories);
    }

    [HttpDelete("category/{id}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken token)
    {
        await _mediator.Send(new DeleteCategory(id), token);
        return NoContent();
    }

    [HttpPut("category/{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateCategory command, CancellationToken token)
    {
        var category = await _mediator.Send(command with { CategoryId = id }, token);
        return Ok(category);
    }
}
