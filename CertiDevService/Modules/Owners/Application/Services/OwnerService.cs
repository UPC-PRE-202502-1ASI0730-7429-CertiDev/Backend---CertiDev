using CertiDevService.Modules.Owners.Domain.Entities;
using CertiDevService.Modules.Owners.Infrastructure.Repositories;

namespace CertiDevService.Modules.Owners.Application.Services
{
    public class OwnerService
    {
        private readonly OwnerRepository _repo;
        public OwnerService(OwnerRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Owner>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<Owner?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);

        public async Task<Owner> CreateAsync(Owner owner)
        {
            await _repo.AddAsync(owner);
            return owner;
        }
    }
}