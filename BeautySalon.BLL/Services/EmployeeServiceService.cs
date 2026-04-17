using AutoMapper;
using BeautySalon.BLL.DTOs.EmployeeServices;
using BeautySalon.BLL.Services.Interfaces;
using BeautySalon.DAL.Entities;
using BeautySalon.DAL.Repositories;
using EmployeeServiceEntity = BeautySalon.DAL.Entities.EmployeeService;

namespace BeautySalon.BLL.Services
{
    public class EmployeeServiceService : IEmployeeServiceService
    {
        private readonly EmployeeServiceRepository repository;
        private readonly IMapper mapper;

        public EmployeeServiceService(
            EmployeeServiceRepository repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeServiceDto>> GetAllAsync()
        {
            var entities = await repository.GetAllAsync();
            return mapper.Map<IEnumerable<EmployeeServiceDto>>(entities);
        }

        public async Task AddAsync(CreateEmployeeServiceDto dto)
        {
            var entity = mapper.Map<EmployeeServiceEntity>(dto);
            await repository.AddAsync(entity);
        }

        public async Task DeleteAsync(int employeeId, int serviceId)
        {
            await repository.DeleteAsync(employeeId, serviceId);
        }
    }
}