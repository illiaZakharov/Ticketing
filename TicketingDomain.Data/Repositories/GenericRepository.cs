using Microsoft.EntityFrameworkCore;
using TicketingDomain.Data.Entities;
using TicketingDomain.Data.IRepositories;

namespace TicketingDomain.Data.Repositories
{
    internal abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly TicketingDomainContext _dbContext;

        protected GenericRepository(TicketingDomainContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> Add(T entity)
        { 
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> Get(Guid id)
        {
            return await _dbContext.FindAsync<T>(id);
        }

        public virtual async Task Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task Delete(Guid id)
        {
            var existEntity = await _dbContext.FindAsync<T>(id);

            if (existEntity != null)
            {
                existEntity.IsActive = false;
                _dbContext.Entry(existEntity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
