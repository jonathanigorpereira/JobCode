using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Amazon;
using Amazon.Extensions.NETCore.Setup;
using JobCode.Core.Entities;
using JobCode.Core.Services;
using JobCode.Infrastructure.Auth;


namespace JobCode.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services
                .AddRepositorie()
                .AddSecrets(configuration)
                .AddData(configuration);

            return services;
        }

        public static IServiceCollection AddSecrets(this IServiceCollection services, ConfigurationManager configuration)
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

            return services;
        }

        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = new JwtSettings();
            configuration.GetSection("JWT").Bind(settings);

            services.AddSingleton(settings);

            return services;
        }

        public static IServiceCollection AddRepositorie(this IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();
            return services;
        }
    }
}
