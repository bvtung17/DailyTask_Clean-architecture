namespace Backend.Application
{
    using System.Reflection;
    using Backend.Application.PipelineBehaviours;
    using Backend.Application.Validations.Commands;
    using FluentValidation;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// DI.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// AddApplication.
        /// </summary>
        /// <param name="services">Services.</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            // MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // Automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Validator
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(typeof(CreateTaskDailyValidator).Assembly);
            return services;
        }
    }
}
