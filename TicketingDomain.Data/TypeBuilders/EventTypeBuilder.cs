using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingDomain.Data.Entities;

namespace TicketingDomain.Data.TypeBuilders
{
    internal class EventTypeBuilder : BaseTypeBuilder<Event>
    {
        internal override void Configure(EntityTypeBuilder<Event> builder)
        {
            ConfigureBaseEntity(builder);

            builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
            builder.Property(e => e.Description).IsRequired(false).HasMaxLength(500);
            builder.Property(e => e.EventDateTime).IsRequired();
            builder.Property(e => e.Duration).IsRequired();
            builder.Property(e => e.VenueId).IsRequired();

            builder.HasOne(p => p.Ticket)
                .WithOne(t => t.Event)
                .HasForeignKey<Ticket>(t => t.PaymentId);
        }
    }
}
