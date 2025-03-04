using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Amazon;
using Amazon.Extensions.NETCore.Setup;
using JobCode.Core.Entities;
using JobCode.Core.Services;
using JobCode.Infrastructure.Auth;
using Microsoft.EntityFrameworkCore;
using JobCode.Core.Repositories;
using JobCode.Infrastructure.Repositories;


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


            var connectionStringConf = configuration.GetSection("JobCodeDb").Value ?? string.Empty;

            services.AddDbContext<JobCodeDbContext>(o => o.UseSqlServer(connectionStringConf));


            return services;
        }

        public static IServiceCollection AddRepositorie(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>),typeof(RepositoryBase<>));
            services.AddScoped<IUserRepository,UserRepository>();

            services.AddTransient<IAuthService, AuthService>();
            services.AddScoped<IEncryptionService, EncryptionService>();

            return services;
        }
    }
}
