using System.Collections.Generic;
using CertiDevService.Modules.Certificates.Domain.Entities;

namespace CertiDevService.Modules.Owners.Domain.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        // Relación con certificados
        public ICollection<Certificate>? Certificates { get; set; }
    }
}