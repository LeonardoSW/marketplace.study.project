using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace Marketplace.Infra.Context
{
    public static class ContextConfiguration
    {
        public static IServiceCollection ConfigureDbContexts(this IServiceCollection services)
        {
            services.AddDbContextPool<PostgresContext>((provider, option) =>
            {
                option.UseNpgsql("Server=database-1.cv62ty9hdyti.us-east-2.rds.amazonaws.com;Port=5432;Userid=postgres;Password=2S92n&Tu2ai43QTiI*5M3vVn5a^$!;SSL=false;Timeout=15;SslMode=Disable;Database=postgres");
            });

            return services;
        }
    }
}
