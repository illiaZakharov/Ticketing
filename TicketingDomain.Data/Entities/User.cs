using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingDomain.Data.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        [StringLength(200)]
        public string EmailAddress { get; set; }
        
        [Required]
        [Phone]
        [StringLength(30)]
        public string PhoneNumber { get; set; }
        
        [Required]
        [StringLength(200)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [ForeignKey("Role")]
        public Guid RoleId { get; set; }
        public virtual UserRole Role { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
