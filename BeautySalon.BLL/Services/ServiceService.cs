using AutoMapper;
using BeautySalon.BLL.DTOs.Services;
using BeautySalon.BLL.Services.Interfaces;
using BeautySalon.DAL.Entities;
using BeautySalon.DAL.Repositories;

namespace BeautySalon.BLL.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IRepository<Service> repository;
        private readonly IMapper mapper;

        public ServiceService(IRepository<Service> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ServiceDto>> GetAllAsync()
        {
            var entities = await repository.GetAllAsync();
            return mapper.Map<IEnumerable<ServiceDto>>(entities);
        }

        public async Task<ServiceDto?> GetByIdAsync(int id)
        {
            var entity = await repository.GetByIdAsync(id);

            if (entity == null)
                return null;

            return mapper.Map<ServiceDto>(entity);
        }

        public async Task<ServiceDto> CreateAsync(CreateServiceDto dto)
        {
            var entity = mapper.Map<Service>(dto);

            await repository.AddAsync(entity);

            return mapper.Map<ServiceDto>(entity);
        }

        public async Task UpdateAsync(int id, UpdateServiceDto dto)
        {
            var entity = await repository.GetByIdAsync(id);

            if (entity == null)
                return;

            mapper.Map(dto, entity);

            await repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ServiceDto>> GetByCategoryIdAsync(int categoryId)
        {
            var services = await repository.GetAllAsync();

            var filtered = services.Where(s => s.CategoryId == categoryId);

            return mapper.Map<IEnumerable<ServiceDto>>(filtered);
        }
    }
}