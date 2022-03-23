using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Contracts.Services;
using DailyTask.Application.Features.DailyTasks.Handlers;
using DailyTask.Application.PipelineBehaviours;
using DailyTask.Application.Validations.Commands;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DailyTask.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //DI
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITaskDailyService, TaskDailyService>();
            //MediatR
            services.AddMediatR(typeof(GetTaskDailyByIdQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetAllTaskDailyQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateTaskDailyCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteTaskDailyCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateTaskDailyCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetUserByIdQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetAllUserQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateUserCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteUserCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateUserCommandHandler).GetTypeInfo().Assembly);
            //Validator

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(typeof(CreateTaskDailyValidator).Assembly);
            return services;
        }
    }
}
