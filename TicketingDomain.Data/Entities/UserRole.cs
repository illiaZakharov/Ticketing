using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingDomain.Data.Entities
{
    public class UserRole : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public int SeqId { get; set; } = 1;

        public virtual ICollection<User> Users { get; set; }

        public UserRole() 
        {
            Users = new HashSet<User>();
        }
    }
}
