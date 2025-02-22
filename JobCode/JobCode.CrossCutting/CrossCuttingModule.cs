using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Internal;
using JobCode.Core.Services;
using JobCode.CrossCutting.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobCode.CrossCutting
{
    public static class CrossCuttingModule
    {
        public static IServiceCollection AddCrossCutting(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddSecrects(configuration);

            return services;
        }

        public static IServiceCollection AddSecrects(this IServiceCollection service, ConfigurationManager configuration)
        {
            configuration.AddSystemsManager(source =>
            {
                source.AwsOptions = new AWSOptions
                {
                    Region = RegionEndpoint.USEast1
                };

                source.Path = "/";
                source.ReloadAfter = TimeSpan.FromSeconds(30);
            });

            return service;
        }


    }
}
