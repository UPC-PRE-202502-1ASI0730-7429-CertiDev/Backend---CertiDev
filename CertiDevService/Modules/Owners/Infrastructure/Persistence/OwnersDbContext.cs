using CertiDevService.Modules.Owners.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CertiDevService.Modules.Owners.Infrastructure.Persistence
{
    public class OwnersDbContext : DbContext
    {
        public OwnersDbContext(DbContextOptions<OwnersDbContext> options) : base(options) { }

        public DbSet<Owner> Owners => Set<Owner>();
    }
}