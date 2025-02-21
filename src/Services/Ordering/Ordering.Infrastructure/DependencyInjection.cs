using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure
        (this IServiceCollection services, IConfiguration configuration)
    {
        string connecitonString = configuration.GetConnectionString("OrderingDb");
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            
            options.UseSqlServer(connecitonString);
        });
        
        return services;
    }
}