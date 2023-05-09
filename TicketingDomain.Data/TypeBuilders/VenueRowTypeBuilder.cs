using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingDomain.Data.Entities;

namespace TicketingDomain.Data.TypeBuilders
{
    internal class VenueRowTypeBuilder : BaseTypeBuilder<VenueRow>
    {
        internal override void Configure(EntityTypeBuilder<VenueRow> builder)
        {
            ConfigureBaseEntity(builder);

            builder.HasOne(e => e.Venue)
                .WithMany(u => u.VenueRows)
                .HasForeignKey(e => e.VenueId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(e => e.Row)
                .WithMany(u => u.VenueRows)
                .HasForeignKey(e => e.RowId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
