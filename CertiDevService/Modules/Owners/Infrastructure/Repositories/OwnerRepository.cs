using CertiDevService.Modules.Owners.Domain.Entities;
using CertiDevService.Shared.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CertiDevService.Modules.Owners.Infrastructure.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly CertiDevDbContext _context;

        public OwnerRepository(CertiDevDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Owner>> GetAllAsync()
        {
            return await _context.Owners
                .Include(o => o.Certificates)
                .ToListAsync();
        }

        public async Task<Owner?> GetByIdAsync(int id)
        {
            return await _context.Owners
                .Include(o => o.Certificates)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task AddAsync(Owner owner)
        {
            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Owner owner)
        {
            _context.Owners.Update(owner);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Owners.FindAsync(id);
            if (entity != null)
            {
                _context.Owners.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}