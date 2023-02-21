namespace Backend.Infrastructure.Persistence
{
    using Backend.Infrastructure.Persistence.Configurations;
    using Microsoft.EntityFrameworkCore;

    public class DailyDbContext : DbContext
    {
        public DailyDbContext(DbContextOptions options) : base(options)
        {

        }     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DailyTaskConfiguration());
        }
        public DbSet<Domain.Entities.DailyTask> TaskDailies { get; set; }
    }
}
