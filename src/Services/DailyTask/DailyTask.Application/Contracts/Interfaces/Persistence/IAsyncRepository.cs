using DailyTask.Domain.Common;

namespace DailyTask.Application.Contracts.Interfaces.Persistence
{
    public interface IAsyncRepository<T> where T : EntityBase
    {
        IQueryable<T> AsQueryable();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}