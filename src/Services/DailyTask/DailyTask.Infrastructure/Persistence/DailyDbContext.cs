using DailyTask.Domain.Entities;
using DailyTask.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DailyTask.Infrastructure.Persistence
{
    public class DailyDbContext : DbContext
    {
        public DailyDbContext(DbContextOptions options) : base(options)
        {

        }     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TaskDailyConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskDaily> TaskDailies { get; set; }
    }
}
