using CookBlog.Application.Abstractions;
using CookBlog.Infrastructure.Logging.Decorators;
using Microsoft.Extensions.DependencyInjection;

namespace CookBlog.Infrastructure.Logging;

internal static class Extensions
{
    public static IServiceCollection AddCustomLogging(this IServiceCollection services)
    {
        services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));

        return services;
    }
}
