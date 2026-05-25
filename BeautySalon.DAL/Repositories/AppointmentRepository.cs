using BeautySalon.DAL.Data;
using BeautySalon.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeautySalon.DAL.Repositories
{
    public class AppointmentRepository
    {
        private readonly BeautySalonDBContext context;

        public AppointmentRepository(BeautySalonDBContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAllWithDetailsAsync()
        {
            return await context.Appointments
                .Include(a => a.Service)
                .Include(a => a.Employee)
                .Include(a => a.Client)
                .ToListAsync();
        }

        public async Task<Appointment?> GetByIdWithDetailsAsync(int id)
        {
            return await context.Appointments
                .Include(a => a.Service)
                .Include(a => a.Employee)
                .Include(a => a.Client)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetByClientIdAsync(int clientId)
        {
            return await context.Appointments
                .Include(a => a.Service)
                .Include(a => a.Employee)
                .Where(a => a.ClientId == clientId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByEmployeeAndDateAsync(
            int employeeId, DateTime date)
        {
            return await context.Appointments
                .Where(a => a.EmployeeId == employeeId &&
                            a.StartTime.Date == date.Date)
                .ToListAsync();
        }
    }
}