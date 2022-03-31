using DailyTask.Domain.Common;

namespace DailyTask.Application.Contracts.Interfaces.Persistence
{
    public interface IAsyncRepository<T> where T : EntityBase
    {
        IQueryable<T> AsQueryable();
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        T Update(T entity);
        T DeleteAsync(T entity);
        Task<IReadOnlyList<T>> GetAll();
    }
}