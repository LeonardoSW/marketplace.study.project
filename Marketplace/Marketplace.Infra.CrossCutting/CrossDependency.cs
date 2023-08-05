using Marketplace.Domain.Interfaces.Services;
using Marketplace.Domain.Models.Configurations;
using Marketplace.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.Infra.CrossCutting
{
    public static class CrossDependency
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            ConfiguringServices(services);
            ConfiguringOptions(services, configuration);

            return services;
        }

        private static void ConfiguringOptions(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMqConfigModel>(options => configuration.GetSection("RabbitMqConfig").Bind(options));
        }

        private static void ConfiguringServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }
    }
}