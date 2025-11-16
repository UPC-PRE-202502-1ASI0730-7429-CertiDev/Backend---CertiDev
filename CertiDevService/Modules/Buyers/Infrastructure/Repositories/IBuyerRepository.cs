using CertiDevService.Modules.Buyers.Domain.Entities;

namespace CertiDevService.Modules.Buyers.Infrastructure.Repositories
{
    public interface IBuyerRepository
    {
        Task<IEnumerable<Buyer>> GetAllAsync();
        Task<Buyer?> GetByIdAsync(int id);
        Task AddAsync(Buyer buyer);
    }
}