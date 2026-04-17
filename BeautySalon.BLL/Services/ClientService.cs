using AutoMapper;
using BeautySalon.BLL.DTOs.Clients;
using BeautySalon.BLL.Services.Interfaces;
using BeautySalon.DAL.Entities;
using BeautySalon.DAL.Repositories;

namespace BeautySalon.BLL.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client> repository;
        private readonly IMapper mapper;

        public ClientService(IRepository<Client> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ClientDto>> GetAllAsync()
        {
            var entities = await repository.GetAllAsync();
            return mapper.Map<IEnumerable<ClientDto>>(entities);
        }

        public async Task<ClientDto?> GetByIdAsync(int id)
        {
            var entity = await repository.GetByIdAsync(id);

            if (entity == null)
                return null;

            return mapper.Map<ClientDto>(entity);
        }

        public async Task<ClientDto> CreateAsync(CreateClientDto dto)
        {
            var entity = mapper.Map<Client>(dto);

            await repository.AddAsync(entity);

            return mapper.Map<ClientDto>(entity);
        }

        public async Task UpdateAsync(int id, UpdateClientDto dto)
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
