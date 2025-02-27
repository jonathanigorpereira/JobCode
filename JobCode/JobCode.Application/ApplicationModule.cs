using JobCode.Application.Commands.InsertUser;
using Microsoft.Extensions.DependencyInjection;

namespace JobCode.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddHandlers();
                //.AddValidation();

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services
                .AddMediatR(config =>
                 config.RegisterServicesFromAssemblyContaining<InsertUserCommand>());

            return services;
        }

        //private static IServiceCollection AddValidation(this IServiceCollection services)
        //{
        //    return services;
        //}
    }
}
