using AutoMapper;
using BeautySalon.BLL.DTOs.Employees;
using BeautySalon.BLL.Services.Interfaces;
using BeautySalon.DAL.Entities;
using BeautySalon.DAL.Repositories;

namespace BeautySalon.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> employeeRepository;
        private readonly EmployeeServiceRepository employeeServiceRepository;
        private readonly IMapper mapper;

        public EmployeeService(
            IRepository<Employee> employeeRepository,
            EmployeeServiceRepository employeeServiceRepository,
            IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.employeeServiceRepository = employeeServiceRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var entities = await employeeRepository.GetAllAsync();
            return mapper.Map<IEnumerable<EmployeeDto>>(entities);
        }

        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var entity = await employeeRepository.GetByIdAsync(id);

            if (entity == null)
                return null;

            return mapper.Map<EmployeeDto>(entity);
        }

        public async Task<EmployeeDto> CreateAsync(CreateEmployeeDto dto)
        {
            var entity = mapper.Map<Employee>(dto);

            await employeeRepository.AddAsync(entity);

            return mapper.Map<EmployeeDto>(entity);
        }

        public async Task UpdateAsync(int id, UpdateEmployeeDto dto)
        {
            var entity = await employeeRepository.GetByIdAsync(id);

            if (entity == null)
                return;

            mapper.Map(dto, entity);

            await employeeRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await employeeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeDto>> GetByServiceIdAsync(int serviceId)
        {
            var employeeServices = await employeeServiceRepository.GetAllAsync();

            var employeeIds = employeeServices
                .Where(es => es.ServiceId == serviceId)
                .Select(es => es.EmployeeId)
                .ToList();

            var employees = await employeeRepository.GetAllAsync();

            var filtered = employees
                .Where(e => employeeIds.Contains(e.Id) && e.IsActive);

            return mapper.Map<IEnumerable<EmployeeDto>>(filtered);
        }
    }
}