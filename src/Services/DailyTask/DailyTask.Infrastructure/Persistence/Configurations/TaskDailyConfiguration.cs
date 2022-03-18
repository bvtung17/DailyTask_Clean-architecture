using DailyTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyTask.Infrastructure.Persistence.Configurations
{
    public class TaskDailyConfiguration : IEntityTypeConfiguration<TaskDaily>
    {
        public void Configure(EntityTypeBuilder<TaskDaily> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Title).IsRequired();
            builder.Property(_ => _.TimeStart).IsRequired();
            builder.Property(_ => _.TimeEnd).IsRequired();
            builder.HasOne(_ => _.User).WithMany(_ => _.TaskDailies)
                .HasForeignKey(_ => _.UserId);
        }
    }
}
