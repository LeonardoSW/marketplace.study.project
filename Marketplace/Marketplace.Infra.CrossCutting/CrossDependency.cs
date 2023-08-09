using Marketplace.Domain.Interfaces.Repositories;
using Marketplace.Domain.Interfaces.Services;
using Marketplace.Domain.Models.Configurations;
using Marketplace.Infra.Repository;
using Marketplace.Services;
using Marketplace.Services.RabbitMqServiceHandlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.Infra.CrossCutting
{
    public static class CrossDependency
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            ConfiguringServices(services);
            ConfiguringRepositories(services);
            ConfiguringOptions(services, configuration);

            return services;
        }
        private static void ConfiguringServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddSingleton<IRabbitMqSenderHandler, RabbitMqSenderHandler>();
        }

        private static void ConfiguringRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }

        private static void ConfiguringOptions(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMqConfigModel>(options =>
                     configuration.GetSection("RabbitMqConfig").Bind(options));
        }
    }
}