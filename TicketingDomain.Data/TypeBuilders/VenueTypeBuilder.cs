using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingDomain.Data.Entities;

namespace TicketingDomain.Data.TypeBuilders
{
    internal class VenueTypeBuilder : BaseTypeBuilder<Venue>
    {
        internal override void Configure(EntityTypeBuilder<Venue> builder)
        {
            ConfigureBaseEntity(builder);

            builder.Property(v => v.Name).IsRequired().HasMaxLength(200);
            builder.Property(v => v.Description).IsRequired(false).HasMaxLength(500);
            builder.Property(v => v.LocationId).IsRequired();

            builder.HasOne(v => v.Event)
                .WithOne(e => e.Venue)
                .HasForeignKey<Event>(e => e.VenueId);
        }
    }
}
