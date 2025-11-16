namespace CertiDevService.Modules.Buyers.Domain.Entities
{
    public class Buyer
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        // Relación con los Owners (por ejemplo, puede comprar certificados de un Owner)
        public int? OwnerId { get; set; }
        public Owners.Domain.Entities.Owner? Owner { get; set; }
    }
}