using DailyTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyTask.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.UserName).IsRequired()
                .HasMaxLength(250);
            builder.HasIndex(_ => _.UserName).IsUnique();
            builder.Property(_ => _.Password).IsRequired()
               .HasMaxLength(250);          
        }
    }
}
