using eTickets.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace eTickets.Models.Repositories
{
    public class Repository<T> : IRepository<T> where T :class, IEntityBase , new()
    {
        private readonly AppDbContext context;

        public Repository(AppDbContext context )
        {
            this.context = context;
        }

        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }


        public async Task<T> GetEntityAsync(int id)
        {
          var result=  await context.Set<T>().FirstOrDefaultAsync(x=>x.id==id);
                return result;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            var result = await context.Set<T>().ToListAsync();

            return result;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T,object>>[] includeProperties)
        {
            IQueryable<T> query = context.Set<T>();

            query = includeProperties.Aggregate(query,(current, includeProperties) => current.Include(includeProperties));
            var result = await query.ToListAsync();
            return result;
        }
        public async Task UpdateAsync(T entity)
        {
            EntityEntry entityEntry =  context.Entry<T>(entity);
            entityEntry.State=EntityState.Modified;
             await context.SaveChangesAsync();
        }
        public async Task Delete(T entity )
        {
            EntityEntry entityEntry = context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await context.SaveChangesAsync();

        }
    }
}
