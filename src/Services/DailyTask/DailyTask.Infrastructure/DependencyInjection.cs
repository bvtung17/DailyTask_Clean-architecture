using DailyTask.Application.Contracts.Interfaces.Persistence;
using DailyTask.Domain.Entities;
using DailyTask.Infrastructure.Cache;
using DailyTask.Infrastructure.Persistence;
using DailyTask.Infrastructure.Repositories;
using Hangfire;
using Hangfire.PostgreSql;
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
            services.Configure<CacheConfiguration>(configuration.GetSection("CacheConfiguration"));
            services.AddMemoryCache();
            services.AddTransient<MemoryCacheService>();
            services.AddTransient<RedisCacheService>();
            services.AddSingleton<Func<CacheTech, ICacheService>>(serviceProvider => key =>
            {
                return key switch
                {
                    CacheTech.Memory => serviceProvider.GetService<MemoryCacheService>(),
                    CacheTech.Redis => serviceProvider.GetService<RedisCacheService>(),
                    _ => serviceProvider.GetService<MemoryCacheService>(),
                };
            });
            services.AddHangfire(config =>
                config.UsePostgreSqlStorage(configuration.GetConnectionString("DailyTaskContext")));
            services.AddHangfireServer();
            return services;
        }
    }
}
