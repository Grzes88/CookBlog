using CookBlog.Application.Abstractions;
using CookBlog.Infrastructure.DAL.Decorators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CookBlog.Infrastructure.DAL;

internal static class Extensions
{
    private const string OptionsSectionName = "mySql";

    public static IServiceCollection AddMySql(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MySqlOptions>(configuration.GetRequiredSection(OptionsSectionName));
        var postgresOptions = configuration.GetOptions<MySqlOptions>(OptionsSectionName);
        services.AddDbContext<MyCookBlogDbContext>(x => x.UseSqlServer(postgresOptions.ConnectionString));
        // services.AddScoped<IWeeklyParkingSpotRepository, PostgresWeeklyParkingSpotRepository>();
        // services.AddScoped<IUserRepository, PostgresUserRepository>();
        // services.AddHostedService<DatabaseInitializer>();
        // services.AddScoped<IUnitOfWork, PostgresUnitOfWork>();

        services.TryDecorate(typeof(ICommandHandler<>), typeof(UnitOfWorkCommandHandlerDecorator<>));

        // EF Core + Npgsql issue
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); // to do obslugi POSTGRES, jest cos takiego do ogslugi w mySQL?

        return services;
    }
}