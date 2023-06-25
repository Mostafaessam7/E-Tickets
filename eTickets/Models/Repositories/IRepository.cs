using System.Linq.Expressions;

namespace eTickets.Models.Repositories
{
    public interface IRepository<T> where T : IEntityBase
    { 
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetEntityAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task Delete( T entity );
    }
}
