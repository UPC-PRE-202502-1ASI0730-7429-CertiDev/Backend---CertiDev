using CertiDevService.Modules.Buyers.Domain.Entities;
using CertiDevService.Shared.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CertiDevService.Modules.Buyers.Infrastructure.Repositories
{
    public class BuyerRepository : IBuyerRepository
    {
        private readonly CertiDevDbContext _context;

        public BuyerRepository(CertiDevDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Buyer>> GetAllAsync()
        {
            return await _context.Buyers
                .Include(b => b.Owner)
                .ToListAsync();
        }

        public async Task<Buyer?> GetByIdAsync(int id)
        {
            return await _context.Buyers
                .Include(b => b.Owner)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddAsync(Buyer buyer)
        {
            _context.Buyers.Add(buyer);
            await _context.SaveChangesAsync();
        }
    }
}