using JobCode.Core.Services;
using JobCode.CrossCutting.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobCode.CrossCutting
{
    public static class CrossCuttingModule
    {
        public static IServiceCollection AddCrossCutting(this IServiceCollection services)
        {
            services.AddServices();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddScoped<IEncryptionService, EncryptionService>();

            return service;
        }
    }
}
