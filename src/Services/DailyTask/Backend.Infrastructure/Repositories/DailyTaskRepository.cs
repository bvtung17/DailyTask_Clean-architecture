namespace Backend.Infrastructure.Repositories
{
    using Backend.Application.Common;
    using Backend.Application.Contracts.Interfaces.Persistence;
    using Backend.Domain.Entities;
    using Backend.Infrastructure.Persistence;

    /// <summary>
    /// The repository base.
    /// </summary>
    /// <typeparam name="T">The entity base.</typeparam>
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
    }
}