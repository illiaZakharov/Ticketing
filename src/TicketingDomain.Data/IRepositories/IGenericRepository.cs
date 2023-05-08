using TicketingDomain.Data.Entities;

namespace TicketingDomain.Data.IRepositories
{
    internal interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> Add(T entity);
        Task<T> Get(Guid id);
        Task Update(T entity);
        Task Delete(Guid id);
    }
}
