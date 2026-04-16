using BeautySalon.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace BeautySalon.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BeautySalonDBContext dbContext;
        private readonly DbSet<T> set;

        public Repository(BeautySalonDBContext dbContext)
        {
            this.dbContext = dbContext;
            set = dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await set.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await set.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await set.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            var keyValue = entity.GetType().GetProperty("Id")?.GetValue(entity);

            if (keyValue == null)
                throw new ArgumentException("Entity must have a non-null Id.");

            var existing = await set.FindAsync(keyValue);

            if (existing != null)
            {
                dbContext.Entry(existing).CurrentValues.SetValues(entity);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await set.FindAsync(id);
            if (entity != null)
            {
                set.Remove(entity);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}