using AutoMapper;
using BeautySalon.BLL.DTOs.Appointments;
using BeautySalon.BLL.Services.Interfaces;
using BeautySalon.DAL.Entities;
using BeautySalon.DAL.Repositories;

namespace BeautySalon.BLL.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<Appointment> appointmentRepository;
        private readonly IRepository<Service> serviceRepository;
        private readonly IRepository<Employee> employeeRepository;
        private readonly EmployeeServiceRepository employeeServiceRepository;
        private readonly IMapper mapper;

        public AppointmentService(
            IRepository<Appointment> appointmentRepository,
            IRepository<Service> serviceRepository,
            IRepository<Employee> employeeRepository,
            EmployeeServiceRepository employeeServiceRepository,
            IMapper mapper)
        {
            this.appointmentRepository = appointmentRepository;
            this.serviceRepository = serviceRepository;
            this.employeeRepository = employeeRepository;
            this.employeeServiceRepository = employeeServiceRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAllAsync()
        {
            var entities = await appointmentRepository.GetAllAsync();
            return mapper.Map<IEnumerable<AppointmentDto>>(entities);
        }

        public async Task<AppointmentDto?> GetByIdAsync(int id)
        {
            var entity = await appointmentRepository.GetByIdAsync(id);

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

            await appointmentRepository.AddAsync(entity);

            return mapper.Map<AppointmentDto>(entity);
        }

        public async Task UpdateAsync(int id, UpdateAppointmentDto dto)
        {
            var entity = await appointmentRepository.GetByIdAsync(id);

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

            await appointmentRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await appointmentRepository.DeleteAsync(id);
        }
    }
}