﻿using CookBlog.Application.Abstractions;
using CookBlog.Core.Repositories;
using CookBlog.Infrastructure.DAL.Decorators;
using CookBlog.Infrastructure.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CookBlog.Infrastructure.DAL;

internal static class Extensions
{
    private const string OptionsSectionName = "MSql";
    private const string SectionName = "Redis";

    public static IServiceCollection AddMSql(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MSqlOptions>(configuration.GetRequiredSection(OptionsSectionName));
        var mSqlOptions = configuration.GetOptions<MSqlOptions>(OptionsSectionName);
        services.AddDbContext<MyCookBlogDbContext>(x => x.UseSqlServer(mSqlOptions.ConnectionString));
        services.AddScoped<IUserRepository, MSqlUserRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddHostedService<DatabaseInitializer>();
        services.AddScoped<IUnitOfWork, MSqlUnitOfWork>();
        services.AddScoped<ITagRepository, TagRepository>();

        services.Configure<RedisOptions>(configuration.GetRequiredSection(SectionName));
        var redisOptions = configuration.GetOptions<RedisOptions>(SectionName);
        services.AddStackExchangeRedisCache(redisCacheOptions => { redisCacheOptions.Configuration = redisOptions.Url; });

        services.Decorate<ITagRepository, CacheTagRepository>();
        services.TryDecorate(typeof(ICommandHandler<>), typeof(UnitOfWorkCommandHandlerDecorator<>));

        return services;
    }
}