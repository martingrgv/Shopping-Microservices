using Ordering.Application;
using Ordering.Infrastructure;

namespace Ordering.API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation
        (this IServiceCollection services)
    {
        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        return app;
    }
}