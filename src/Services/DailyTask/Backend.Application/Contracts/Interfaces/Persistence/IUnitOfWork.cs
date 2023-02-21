namespace Backend.Application.Contracts.Interfaces.Persistence
{
    /// <summary>
    /// The unit of work interface.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Begin transaction.
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// commit transaction.
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// Roll back.
        /// </summary>
        void RollbackTransaction();

        /// <summary>
        /// Save change async.
        /// </summary>
        /// <returns>int.</returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Gets the daily task repository.
        /// </summary>
        IDailyTaskRepository DailyTaskRepository { get; }
    }
}
