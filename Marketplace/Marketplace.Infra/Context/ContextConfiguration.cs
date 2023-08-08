using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Marketplace.Infra.Context
{
    public static class ContextConfiguration
    {
        public static IServiceCollection ConfigureDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PostgresContext>((provider, option) =>
                option.UseNpgsql(configuration.GetConnectionString("Postgres")));

            return services;
        }
    }
}
