using DailyTask.Application.Contracts.Interfaces.Persistence;
using DailyTask.Domain.Common;
using DailyTask.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;

namespace DailyTask.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : EntityBase
    {
        private readonly DailyDbContext _db;
        private readonly IMemoryCache _cache;
        public RepositoryBase(DailyDbContext db,IMemoryCache cache)
        {
            _db = db;
            _cache = cache;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            return entity;
        }

        public T DeleteAsync(T entity)
        {
            if (_cache.TryGetValue( entity.Id, out T objecct))
            {
                _db.Set<T>().Remove(entity);
                _cache.Remove(objecct.Id);
                return entity;
            }
            _db.Set<T>().Remove(entity);
            return entity;
        }

        public IQueryable<T> AsQueryable()
        {
             return _db.Set<T>().AsQueryable();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            if (_cache.TryGetValue(id, out T objecct))
            {         
                return objecct;
            }
            var entity = await _db.Set<T>().Where(_ => _.Id == id).FirstOrDefaultAsync();
            if (entity == null)
            {
                return null;
            }
            _cache.Set(entity.Id, entity);
            return entity;
        }

        public T Update(T entity)
        {
            _db.Set<T>().Update(entity);
            if (_cache.TryGetValue(entity.Id, out T objecct))
            {
                _cache.Remove(objecct.Id);
                _cache.Set(entity.Id, entity);
                return entity;
            }
            _cache.Set(entity.Id, entity);
            return entity;
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }
    }
}