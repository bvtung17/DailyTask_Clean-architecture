using DailyTask.Application.Contracts.Persistence;
using DailyTask.Domain.Common;
using DailyTask.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace DailyTask.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DailyDbContext _db;
        private readonly IServiceProvider _serviceProvider;
        private IDbContextTransaction _transaction;
        public UnitOfWork(DailyDbContext db, IServiceProvider serviceProvider)
        {
            _db = db;
            this._serviceProvider = serviceProvider;
        }
        public void BeginTransaction()
        {
            _transaction = _db.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
                _transaction.Dispose();
            }
        }
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public IAsyncRepository<T> GetRepository<T>() where T : EntityBase
        {
            return _serviceProvider.GetService<IAsyncRepository<T>>();
        }

        public void RollbackTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction.Dispose();
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
