using System.ComponentModel.DataAnnotations;

namespace LabbAPI.Models.DTO
{
    public class GetPersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public string? Telefonnummer { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
    }
}
