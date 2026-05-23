using AutoMapper;
using BeautySalon.BLL.DTOs.Clients;
using BeautySalon.BLL.Services.Interfaces;
using BeautySalon.DAL.Entities;
using BeautySalon.DAL.Repositories;

namespace BeautySalon.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<Client> clientRepository;
        private readonly IMapper mapper;

        public AuthService(IRepository<Client> clientRepository, IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.mapper = mapper;
        }

        public async Task<ClientDto?> LoginAsync(string email, string password)
        {
            var clients = await clientRepository.GetAllAsync();
            var client = clients.FirstOrDefault(c =>
                c.Email == email &&
                c.PasswordHash == HashPassword(password));

            return client == null ? null : mapper.Map<ClientDto>(client);
        }

        public async Task<ClientDto> RegisterAsync(CreateClientDto dto)
        {
            var entity = mapper.Map<Client>(dto);
            entity.PasswordHash = HashPassword(dto.Password);
            await clientRepository.AddAsync(entity);
            return mapper.Map<ClientDto>(entity);
        }

        private static string HashPassword(string password)
        {
            using var sha = System.Security.Cryptography.SHA256.Create();
            var bytes = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}