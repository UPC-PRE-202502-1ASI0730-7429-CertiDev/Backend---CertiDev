using CertiDevService.Modules.Owners.Domain.Entities;
using CertiDevService.Modules.Buyers.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CertiDevService.Shared.Infrastructure.Persistence
{
    public class CertiDevDbContext : DbContext
    {
        public CertiDevDbContext(DbContextOptions<CertiDevDbContext> options)
            : base(options) { }

        public DbSet<Owner> Owners => Set<Owner>();
        public DbSet<Buyer> Buyers => Set<Buyer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación 1:N — Owner puede tener muchos Buyers
            modelBuilder.Entity<Buyer>()
                .HasOne(b => b.Owner)
                .WithMany()
                .HasForeignKey(b => b.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}