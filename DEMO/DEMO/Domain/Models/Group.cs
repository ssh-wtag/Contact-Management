using System.ComponentModel.DataAnnotations;

namespace DEMO.Domain.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        [Required]
        public string? GroupName { get; set; }

        public virtual ICollection<Contact>? Contacts { get; set; }
    }
}
