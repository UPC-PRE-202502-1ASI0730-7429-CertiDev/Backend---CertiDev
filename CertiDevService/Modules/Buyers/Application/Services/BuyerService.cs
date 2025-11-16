using CertiDevService.Modules.Buyers.Domain.Entities;
using CertiDevService.Modules.Buyers.Infrastructure.Repositories;

namespace CertiDevService.Modules.Buyers.Application.Services
{
    public class BuyerService
    {
        private readonly IBuyerRepository _repository;

        public BuyerService(IBuyerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Buyer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Buyer?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Buyer> CreateAsync(Buyer buyer)
        {
            await _repository.AddAsync(buyer);
            return buyer;
        }
    }
}