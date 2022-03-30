using DailyTask.Application.Contracts.Interfaces.Persistence;
using DailyTask.Domain.Common;
using DailyTask.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace DailyTask.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : EntityBase
    {
        private readonly DailyDbContext _db;
        private readonly ConcurrentDictionary<int, T> _cache = new ConcurrentDictionary<int, T>();
        public RepositoryBase(DailyDbContext db)
        {
            _db = db;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            return entity;
        }

        public T DeleteAsync(T entity)
        {
            if (_cache.ContainsKey(entity.Id))
            {
                _db.Set<T>().Remove(entity);
                _cache.TryRemove(entity.Id, out entity);
                return entity;
            }
            _db.Set<T>().Remove(entity);
            return entity;
        }

        public IQueryable<T> AsQueryable()
        {
             return _db.Set<T>().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            if (_cache.ContainsKey(id))
            {
                return _cache[id];
            }
            var entity = await _db.Set<T>().Where(_ => _.Id == id).FirstOrDefaultAsync();
            _cache.TryAdd(entity.Id, entity);
            return entity;
        }

        public T Update(T entity)
        {
            _db.Set<T>().Update(entity);
            return entity;
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }
    }
}