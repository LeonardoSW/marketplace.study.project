using Marketplace.Domain.Interfaces.Services;
using Marketplace.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.Infra.CrossCutting
{
    public static class CrossDependency
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}