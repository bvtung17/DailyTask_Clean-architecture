namespace Backend.Infrastructure.Repositories
{
    using Backend.Application.Common;
    using Backend.Application.Contracts.Interfaces.Persistence;
    using Backend.Domain.Common;
    using Backend.Infrastructure.Persistence;

    /// <summary>
    /// The repository base.
    /// </summary>
    /// <typeparam name="T">The entity base.</typeparam>
    public class RepositoryBase<T> : IGenericRepository<T>
        where T : EntityBase
    {
        private readonly DailyDbContext db;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{T}"/> class.
        /// </summary>
        /// <param name="db">The db context.</param>
        public RepositoryBase(DailyDbContext db)
        {
            this.db = db;
        }

        /// <inheritdoc/>
        public async Task AddAsync(T entity)
        {
            await this.db.Set<T>().AddAsync(entity);
        }

        /// <inheritdoc/>
        public void Delete(T entity)
        {
            this.db.Set<T>().Remove(entity);
        }

        /// <inheritdoc/>
        public IQueryable<T> AsQueryable()
        {
            return this.db.Set<T>().AsQueryable();
        }

        /// <inheritdoc/>
        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await this.db.Set<T>().FindAsync(id);
            return entity;
        }

        /// <inheritdoc/>
        public void Update(T entity)
        {
            this.db.Set<T>().Update(entity);
        }
    }
}