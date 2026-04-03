namespace Backend.Infrastructure.Repositories
{
    using Backend.Application.Common;
    using Backend.Application.Contracts.Interfaces.Persistence;
    using Backend.Domain.Common;
    using Backend.Domain.Entities;
    using Backend.Infrastructure.Persistence;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The daily task repository.
    /// </summary>
    public class DailyTaskRepository : RepositoryBase<DailyTask>, IDailyTaskRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DailyTaskRepository"/> class.
        /// </summary>
        /// <param name="db">Db context.</param>
        public DailyTaskRepository(DailyDbContext db)
            : base(db)
        {
        }

        /// <inheritdoc/>
        public async Task<List<DailyTask>> GetByStatusAsync(Status status, int take)
        {
            return await this.AsQueryable()
                .Where(t => t.Status == status)
                .Take(take)
                .ToListAsync();
        }
    }
}