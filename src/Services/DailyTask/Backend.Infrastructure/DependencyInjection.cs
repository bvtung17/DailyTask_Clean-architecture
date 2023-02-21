namespace Backend.Infrastructure
{
    using Backend.Application.Contracts.Interfaces.Persistence;
    using Backend.Infrastructure.Persistence;
    using Backend.Infrastructure.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<DailyDbContext>(option =>
            {
                option.UseNpgsql(configuration.GetConnectionString("DailyTaskContext"));
            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(RepositoryBase<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddMemoryCache();
            return services;
        }
    }
}
