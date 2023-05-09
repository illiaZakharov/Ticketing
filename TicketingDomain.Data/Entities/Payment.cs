using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingDomain.Data.Entities
{
    public class Payment : BaseEntity
    {
        [Required]
        public decimal Amount { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Method { get; set; } // e.g. credit card, PayPal

        [Required]
        [StringLength(50)]
        public string Status { get; set; } // e.g. pending, completed, failed

        public virtual Ticket Ticket { get; set; }
    }
}
