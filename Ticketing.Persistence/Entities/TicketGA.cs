using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing.Persistence.Entities
{
    public class TicketGA : BaseEntity
    {
        [Required]
        public decimal Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [Required]
        [ForeignKey(nameof(GeneralAdmission))]
        public Guid GeneralAdmissionId { get; set; }
        public virtual GeneralAdmission GeneralAdmission { get; set; }
    }
}
