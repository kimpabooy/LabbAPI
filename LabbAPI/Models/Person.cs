using System.ComponentModel.DataAnnotations;

namespace LabbAPI.Models
{
    public class Person
    {
        public int Id { get; set; }
        
        [Required]
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public string? Telefonnummer { get; set; }
        
        [EmailAddress]
        public string? Email { get; set; }

        public ICollection<PersonInterest>? PersonInterests { get; set; }
        
    }
}
