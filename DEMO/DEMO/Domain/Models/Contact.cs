using System.ComponentModel.DataAnnotations;

namespace DEMO.Domain.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Number { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Group>? Groups { get; set; }
    }
}
