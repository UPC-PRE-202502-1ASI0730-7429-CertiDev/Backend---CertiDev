namespace CertiDevService.Modules.Owners.Application.DTOs
{
    public class OwnerDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}