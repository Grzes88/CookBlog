using CookBlog.Application.Abstractions;
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

    public static IServiceCollection AddMSql(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MSqlOptions>(configuration.GetRequiredSection(OptionsSectionName));
        var mSqlOptions = configuration.GetOptions<MSqlOptions>(OptionsSectionName);
        services.AddDbContext<MyCookBlogDbContext>(x => x.UseSqlServer(mSqlOptions.ConnectionString));
        services.AddScoped<IUserRepository, MSqlUserRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddHostedService<DatabaseInitializer>();
        services.AddScoped<IUnitOfWork, MSqlUnitOfWork>();

        services.TryDecorate(typeof(ICommandHandler<>), typeof(UnitOfWorkCommandHandlerDecorator<>));

        return services;
    }
}