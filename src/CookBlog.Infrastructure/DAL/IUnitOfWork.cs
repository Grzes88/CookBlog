﻿namespace CookBlog.Infrastructure.DAL;

public interface IUnitOfWork
{
    Task ExecuteAsync(Func<Task> action);
}
