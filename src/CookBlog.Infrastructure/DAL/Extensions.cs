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
        var postgresOptions = configuration.GetOptions<MSqlOptions>(OptionsSectionName);
        services.AddDbContext<MyCookBlogDbContext>(x => x.UseSqlServer(postgresOptions.ConnectionString));
        services.AddScoped<IUserRepository, MSqlUserRepository>();
        services.AddScoped<ICategoryRepository, MSqlCategoryRepository>();
        services.AddHostedService<DatabaseInitializer>();
        services.AddScoped<IUnitOfWork, MSqlUnitOfWork>();

        services.TryDecorate(typeof(ICommandHandler<>), typeof(UnitOfWorkCommandHandlerDecorator<>));

        // EF Core + Npgsql issue
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        return services;
    }
}