using CertiDevService.Modules.Owners.Domain.Entities;

namespace CertiDevService.Modules.Owners.Infrastructure.Repositories
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<Owner>> GetAllAsync();
        Task<Owner?> GetByIdAsync(int id);
        Task AddAsync(Owner owner);
        Task UpdateAsync(Owner owner);
        Task DeleteAsync(int id);
    }
}