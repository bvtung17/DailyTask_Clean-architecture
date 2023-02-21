namespace Backend.Infrastructure.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// The daily task configuarion.
    /// </summary>
    public class DailyTaskConfiguration : IEntityTypeConfiguration<Domain.Entities.DailyTask>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Domain.Entities.DailyTask> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Title).IsRequired();
            builder.Property(_ => _.TimeStart).IsRequired();
            builder.Property(_ => _.TimeEnd).IsRequired();
        }
    }
}
