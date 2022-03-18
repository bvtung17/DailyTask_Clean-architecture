using DailyTask.Application.Contracts.Persistence;
using DailyTask.Domain.Common;
using DailyTask.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DailyTask.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : EntityBase
    {
        private readonly DailyDbContext _db;
        public RepositoryBase(DailyDbContext db)
        {
            _db = db;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);         
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _db.Set<T>().Where(_=>_.Id == id).FirstOrDefaultAsync();
        }

        public void Update(T entity)
        {
            _db.Set<T>().Update(entity);
        }
    }
}