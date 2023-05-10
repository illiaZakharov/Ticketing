using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing.Persistence.Entities
{
    public class Zone : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [ForeignKey(nameof(Venue))]
        public Guid VenueId { get; set; }
        public virtual Venue Venue { get; set; }

        public virtual ICollection<Seat> Seats { get; set; }
        public virtual ICollection<GeneralAdmission> GeneralAdmissions { get; set; }

        public Zone()
        {
            Seats = new HashSet<Seat>();
            GeneralAdmissions = new HashSet<GeneralAdmission>();
        }
    }
}
