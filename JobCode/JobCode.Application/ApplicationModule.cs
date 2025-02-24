using JobCode.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace JobCode.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddMapper()
                .AddHandlers()
                .AddValidation();

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            //services.AddMediatR(config =>
            //    config.RegisterServicesFromAssemblyContaining<>());

            return services;
        }

        private static IServiceCollection AddValidation(this IServiceCollection services)
        {
            //services
            //    .AddFluentValidationAutoValidation()
            //    .AddValidatorsFromAssemblyContaining<InsertProjectCommand>();

            return services;
        }

        private static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            return services;
        }

    }
}
