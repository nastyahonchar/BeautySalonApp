using AutoMapper;
using BeautySalon.BLL.DTOs.Appointments;
using BeautySalon.BLL.Services.Interfaces;
using BeautySalon.DAL.Entities;
using BeautySalon.DAL.Repositories;

namespace BeautySalon.BLL.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<Appointment> repository;
        private readonly AppointmentRepository appointmentRepository;
        private readonly IRepository<Service> serviceRepository;
        private readonly IRepository<Employee> employeeRepository;
        private readonly EmployeeServiceRepository employeeServiceRepository;
        private readonly IMapper mapper;
        private readonly IRepository<EmployeeSchedule> scheduleRepository;

        public AppointmentService(
            IRepository<Appointment> repository,
            AppointmentRepository appointmentRepository,
            IRepository<Service> serviceRepository,
            IRepository<Employee> employeeRepository,
            EmployeeServiceRepository employeeServiceRepository,
            IMapper mapper,
            IRepository<EmployeeSchedule> scheduleRepository)
        {
            this.repository = repository;
            this.appointmentRepository = appointmentRepository;
            this.serviceRepository = serviceRepository;
            this.employeeRepository = employeeRepository;
            this.employeeServiceRepository = employeeServiceRepository;
            this.mapper = mapper;
            this.scheduleRepository = scheduleRepository;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAllAsync()
        {
            var entities = await appointmentRepository.GetAllWithDetailsAsync();
            return mapper.Map<IEnumerable<AppointmentDto>>(entities);
        }

        public async Task<AppointmentDto?> GetByIdAsync(int id)
        {
            var entity = await appointmentRepository.GetByIdWithDetailsAsync(id);

            if (entity == null)
                return null;

            return mapper.Map<AppointmentDto>(entity);
        }

        public async Task<AppointmentDto> CreateAsync(CreateAppointmentDto dto)
        {
            var relations = await employeeServiceRepository.GetAllAsync();

            var isAllowed = relations.Any(x =>
                x.EmployeeId == dto.EmployeeId &&
                x.ServiceId == dto.ServiceId);

            if (!isAllowed)
                throw new Exception("This employee does not perform the selected service.");

            var service = await serviceRepository.GetByIdAsync(dto.ServiceId);

            if (service == null)
                throw new Exception("Service not found");

            var employee = await employeeRepository.GetByIdAsync(dto.EmployeeId);

            if (employee == null || !employee.IsActive)
                throw new Exception("Employee not found or inactive");

            var entity = mapper.Map<Appointment>(dto);

            entity.EndTime = dto.StartTime.AddMinutes(service.DurationMinutes);
            entity.TotalPrice = service.Price;
            entity.Status = "Pending";

            await repository.AddAsync(entity);

            var created = await appointmentRepository
                .GetByIdWithDetailsAsync(entity.Id);

            return mapper.Map<AppointmentDto>(created);
        }

        public async Task UpdateAsync(int id, UpdateAppointmentDto dto)
        {
            var entity = await repository.GetByIdAsync(id);

            if (entity == null)
                return;

            entity.StartTime = dto.StartTime;
            entity.Status = dto.Status;

            var service = await serviceRepository.GetByIdAsync(entity.ServiceId);

            if (service != null)
            {
                entity.EndTime = entity.StartTime.AddMinutes(service.DurationMinutes);
                entity.TotalPrice = service.Price;
            }

            await repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<AppointmentDto>> GetByClientIdAsync(int clientId)
        {
            var entities = await appointmentRepository.GetByClientIdAsync(clientId);
            return mapper.Map<IEnumerable<AppointmentDto>>(entities);
        }

        public async Task<IEnumerable<string>> GetAvailableSlotsAsync(int employeeId, int serviceId, DateTime date)
        {
            var schedules = await scheduleRepository.GetAllAsync();
            var daySchedule = schedules.FirstOrDefault(s =>
                s.EmployeeId == employeeId &&
                s.DayOfWeek == date.DayOfWeek);

            if (daySchedule == null)
                return Enumerable.Empty<string>();

            var service = await serviceRepository.GetByIdAsync(serviceId);
            if (service == null)
                return Enumerable.Empty<string>();

            int duration = service.DurationMinutes;

            var dayAppointments = await appointmentRepository.GetByEmployeeAndDateAsync(employeeId, date);

            var slots = new List<string>();
            var current = date.Date + daySchedule.WorkStart;
            var workEnd = date.Date + daySchedule.WorkEnd;

            var now = DateTime.Now;

            while (current.AddMinutes(duration) <= workEnd)
            {
                if (current < now)
                {
                    current = current.AddMinutes(30);
                    continue;
                }

                bool isBusy = dayAppointments.Any(a =>
                    current < a.EndTime &&
                    current.AddMinutes(duration) > a.StartTime);

                if (!isBusy)
                    slots.Add(current.ToString("HH:mm"));

                current = current.AddMinutes(30);
            }

            return slots;
        }
    }
}