using CookBlog.Core.Entities;
using CookBlog.Core.Repositories;
using CookBlog.Core.ValuesObjects;
using Microsoft.EntityFrameworkCore;

namespace CookBlog.Infrastructure.DAL.Repositories;

internal sealed class MSqlUserRepository : IUserRepository
{
    private readonly DbSet<User> _users;

    public MSqlUserRepository(MyCookBlogDbContext dbContext)
    {
        _users = dbContext.Users;
    }

    public async Task AddAsync(User user)
    {
        await _users.AddAsync(user);
    }

    public Task<User> GetByIdAsync(UserId id)
    {
        return _users.SingleOrDefaultAsync(x => x.Id == id);
    }

    public Task<User> GetByEmailAsync(Email email)
    {
        return _users.SingleOrDefaultAsync(u => u.Email == email);
    }

    public Task<User> GetByUserNameAsync(UserName userName)
    {
        return _users.SingleOrDefaultAsync(u => u.UserName == userName);
    }
}
