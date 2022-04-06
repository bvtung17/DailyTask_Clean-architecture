using DailyTask.Application.Contracts.Interfaces.Persistence;
using DailyTask.Domain.Common;
using DailyTask.Infrastructure.Cache;
using DailyTask.Infrastructure.Persistence;
using Hangfire;
using Microsoft.EntityFrameworkCore;

namespace DailyTask.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : EntityBase
    {
        private readonly DailyDbContext _db;
        private readonly static CacheTech cacheTech = CacheTech.Memory;
        private readonly string cacheKey = $"{typeof(T)}";
        private readonly Func<CacheTech, ICacheService> _cacheService;
        public RepositoryBase(DailyDbContext db, Func<CacheTech, ICacheService> cacheService)
        {
            _db = db;
            _cacheService = cacheService;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            BackgroundJob.Enqueue(() => RefreshCache());
            return entity;
        }

        public T DeleteAsync(T entity)
        {
            _db.Set<T>().Remove(entity);
            BackgroundJob.Enqueue(() => RefreshCache());
            return entity;
        }

        public IQueryable<T> AsQueryable()
        {
            return _db.Set<T>().AsQueryable();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            if (!_cacheService(cacheTech).TryGet(cacheKey, out IReadOnlyList<T> cachedList))
            {
                cachedList = await _db.Set<T>().ToListAsync();
                _cacheService(cacheTech).Set(cacheKey, cachedList);
            }
            foreach (var item in cachedList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            var entity = await _db.Set<T>().FindAsync(id);       
            return entity;
        }

        public T Update(T entity)
        {
            _db.Set<T>().Update(entity);
            BackgroundJob.Enqueue(() => RefreshCache());
            return entity;
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            if (!_cacheService(cacheTech).TryGet(cacheKey, out IReadOnlyList<T> cachedList))
            {
                cachedList = await _db.Set<T>().ToListAsync();
                _cacheService(cacheTech).Set(cacheKey, cachedList);
            }
            return cachedList;
        }
        public async Task RefreshCache()
        {
            _cacheService(cacheTech).Remove(cacheKey);
            var cachedList = await _db.Set<T>().ToListAsync();
            _cacheService(cacheTech).Set(cacheKey, cachedList);
        }
    }
}