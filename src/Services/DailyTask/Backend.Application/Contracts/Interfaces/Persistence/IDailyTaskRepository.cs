namespace Backend.Application.Contracts.Interfaces.Persistence
{
    using Backend.Domain.Common;
    using Backend.Domain.Entities;

    /// <summary>
    /// The daily task repository interface.
    /// </summary>
    public interface IDailyTaskRepository : IGenericRepository<DailyTask>
    {
        /// <summary>
        /// Gets tasks by status asynchronously.
        /// </summary>
        /// <param name="status">The status to filter by.</param>
        /// <param name="take">The maximum number of tasks to return.</param>
        /// <returns>A list of tasks with the specified status.</returns>
        Task<List<DailyTask>> GetByStatusAsync(Status status, int take);
    }
}
