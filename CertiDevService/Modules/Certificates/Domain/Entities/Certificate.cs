namespace CertiDevService.Modules.Certificates.Domain.Entities
{
    public class Certificate
    {
        public int Id { get; set; }
        public string Hash { get; set; } = string.Empty;
        public string PropertyName { get; set; } = string.Empty;
        public int OwnerId { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string Status { get; set; } = "emitido"; // emitido | vigente | publicado | revocado
        public string? Observations { get; set; }

        // Navegación
        public CertiDevService.Modules.Owners.Domain.Entities.Owner? Owner { get; set; }
    }
}