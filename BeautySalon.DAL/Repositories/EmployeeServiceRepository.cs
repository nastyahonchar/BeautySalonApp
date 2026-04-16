using BeautySalon.DAL.Data;
using BeautySalon.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeautySalon.DAL.Repositories
{
    public class EmployeeServiceRepository
    {
        private readonly BeautySalonDBContext dbContext;
        private readonly DbSet<EmployeeService> set;

        public EmployeeServiceRepository(BeautySalonDBContext dbContext)
        {
            this.dbContext = dbContext;
            set = dbContext.Set<EmployeeService>();
        }

        public async Task<IEnumerable<EmployeeService>> GetAllAsync()
        {
            return await set.ToListAsync();
        }

        public async Task<EmployeeService?> GetByIdAsync(int employeeId, int serviceId)
        {
            return await set.FindAsync(employeeId, serviceId);
        }

        public async Task AddAsync(EmployeeService entity)
        {
            await set.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(EmployeeService entity)
        {
            var existing = await set.FindAsync(entity.EmployeeId, entity.ServiceId);
            if (existing != null)
            {
                dbContext.Entry(existing).CurrentValues.SetValues(entity);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int employeeId, int serviceId)
        {
            var entity = await set.FindAsync(employeeId, serviceId);
            if (entity != null)
            {
                set.Remove(entity);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
