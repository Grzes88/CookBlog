using CookBlog.Application.Abstractions;
using CookBlog.Application.DTO;
using CookBlog.Application.Queries;
using Microsoft.EntityFrameworkCore;

namespace CookBlog.Infrastructure.DAL.Handlers;

internal sealed class GetUsersHandler : IQueryHandler<GetUsers, IEnumerable<UserDto>>
{
    private readonly MyCookBlogDbContext _dbContext;

    public GetUsersHandler(MyCookBlogDbContext dbContext) 
        => _dbContext = dbContext;

    public async Task<IEnumerable<UserDto>> HandleAsync(GetUsers query) 
        => await _dbContext.Users
            .AsNoTracking()
            .Select(u => u.AsDto())
            .ToListAsync();
}
