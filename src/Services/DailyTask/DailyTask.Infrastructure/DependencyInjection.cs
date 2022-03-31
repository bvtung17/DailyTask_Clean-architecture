using DailyTask.Application.Contracts.Interfaces.Persistence;
using DailyTask.Domain.Entities;
using DailyTask.Infrastructure.Persistence;
using DailyTask.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DailyTask.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<DailyDbContext>(option =>
            {
                option.UseNpgsql(configuration.GetConnectionString("DailyTaskContext"));
            });
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            //services.Decorate<IAsyncRepository<TaskDaily>, RepositoryBase<TaskDaily>>();
            services.AddMemoryCache();
            return services;
        }
    }
}
