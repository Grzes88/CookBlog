﻿namespace CookBlog.Infrastructure.DAL;

internal sealed class MySqlUnitOfWork : IUnitOfWork
{
    private readonly MyCookBlogDbContext _dbContext;

    public MySqlUnitOfWork(MyCookBlogDbContext dbContext) => _dbContext = dbContext;

    public async Task ExecuteAsync(Func<Task> action)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            await action();
            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
