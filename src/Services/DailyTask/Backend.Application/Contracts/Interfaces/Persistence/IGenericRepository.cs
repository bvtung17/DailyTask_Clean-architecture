namespace Backend.Application.Contracts.Interfaces.Persistence
{
    using Backend.Domain.Common;

    /// <summary>
    /// The repository interface.
    /// </summary>
    /// <typeparam name="T">The class.</typeparam>
    public interface IGenericRepository<T>
        where T : EntityBase
    {
        /// <summary>
        /// AsQueryable.
        /// </summary>
        /// <returns>The AsQueryable.</returns>
        IQueryable<T> AsQueryable();

        /// <summary>
        /// GetByIdAsync.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Entity.</returns>
        Task<T> GetByIdAsync(Guid id);

        /// <summary>
        /// Add entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>true/false.</returns>
        Task AddAsync(T entity);

        /// <summary>
        /// Update the enity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);

        /// <summary>
        /// Delete the enity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);
    }
}