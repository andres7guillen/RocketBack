using RocketDomain.Repositories;
using RocketDomain.Services;
using RocketInfrastructure.Repositories;
using RocketInfrastructure.Services;

namespace RocketAPI.Utilities
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IRocketRepository,RocketRepository>();
            services.AddScoped<IRocketService, RocketService>();
            return services;
        }
    }
}
