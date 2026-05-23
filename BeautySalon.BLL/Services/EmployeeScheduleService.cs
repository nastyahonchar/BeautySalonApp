using AutoMapper;
using BeautySalon.BLL.DTOs.EmployeeSchedules;
using BeautySalon.BLL.Services.Interfaces;
using BeautySalon.DAL.Entities;
using BeautySalon.DAL.Repositories;

namespace BeautySalon.BLL.Services
{
    public class EmployeeScheduleService : IEmployeeScheduleService
    {
        private readonly IRepository<EmployeeSchedule> repository;
        private readonly IMapper mapper;

        public EmployeeScheduleService(
            IRepository<EmployeeSchedule> repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeScheduleDto>> GetByEmployeeIdAsync(int employeeId)
        {
            var all = await repository.GetAllAsync();
            var filtered = all.Where(s => s.EmployeeId == employeeId);
            return mapper.Map<IEnumerable<EmployeeScheduleDto>>(filtered);
        }

        public async Task<EmployeeScheduleDto> CreateAsync(CreateEmployeeScheduleDto dto)
        {
            var entity = mapper.Map<EmployeeSchedule>(dto);
            await repository.AddAsync(entity);
            return mapper.Map<EmployeeScheduleDto>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }
    }
}