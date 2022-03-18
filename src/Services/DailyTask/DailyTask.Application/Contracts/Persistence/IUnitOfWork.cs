using DailyTask.Domain.Common;

namespace DailyTask.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        IAsyncRepository<T> GetRepository<T>()
            where T : EntityBase;
        Task<int> SaveChangesAsync();
    }
}
