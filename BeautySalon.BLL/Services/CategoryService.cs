using AutoMapper;
using BeautySalon.BLL.DTOs.Categories;
using BeautySalon.BLL.Services.Interfaces;
using BeautySalon.DAL.Entities;
using BeautySalon.DAL.Repositories;

namespace BeautySalon.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;

        public CategoryService(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var entities = await repository.GetAllAsync();
            return mapper.Map<IEnumerable<CategoryDto>>(entities);
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var entity = await repository.GetByIdAsync(id);

            if (entity == null)
                return null;

            return mapper.Map<CategoryDto>(entity);
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
        {
            var entity = mapper.Map<Category>(dto);

            await repository.AddAsync(entity);

            return mapper.Map<CategoryDto>(entity);
        }

        public async Task UpdateAsync(int id, UpdateCategoryDto dto)
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
    }
}