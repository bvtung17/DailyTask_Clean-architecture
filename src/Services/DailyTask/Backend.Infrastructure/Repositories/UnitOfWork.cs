namespace Backend.Infrastructure.Repositories
{
    using Backend.Application.Contracts.Interfaces.Persistence;
    using Backend.Infrastructure.Persistence;
    using Microsoft.EntityFrameworkCore.Storage;

    /// <summary>
    /// The unit of work.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DailyDbContext dbContext;
        private readonly Lazy<DailyTaskRepository> dailyTaskRepository;
        private IDbContextTransaction transaction;
        private bool disposedValue = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        public UnitOfWork(DailyDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dailyTaskRepository = new Lazy<DailyTaskRepository>(() => new DailyTaskRepository(dbContext));
        }

        /// <inheritdoc/>
        public IDailyTaskRepository DailyTaskRepository => this.dailyTaskRepository.Value;

        /// <inheritdoc/>
        public void BeginTransaction()
        {
            this.transaction = this.dbContext.Database.BeginTransaction();
        }

        /// <inheritdoc/>
        public void CommitTransaction()
        {
            if (this.transaction != null)
            {
                this.transaction.Commit();
                this.transaction.Dispose();
            }
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">true/false.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.dbContext.Dispose();
                }

                this.disposedValue = true;
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <inheritdoc/>
        public void RollbackTransaction()
        {
            if (this.transaction != null)
            {
                this.transaction.Rollback();
                this.transaction.Dispose();
            }
        }

        /// <inheritdoc/>
        public async Task<int> SaveChangesAsync()
        {
            return await this.dbContext.SaveChangesAsync();
        }
    }
}
