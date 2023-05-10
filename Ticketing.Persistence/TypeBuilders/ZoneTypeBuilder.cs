using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticketing.Persistence.Entities;

namespace Ticketing.Persistence.TypeBuilders
{
    internal class ZoneTypeBuilder : BaseTypeBuilder<Zone>
    {
        internal override void Configure(EntityTypeBuilder<Zone> builder)
        {
            ConfigureBaseEntity(builder);

            builder.Property(z => z.Name).IsRequired().HasMaxLength(50);
            builder.Property(z => z.VenueId).IsRequired();

            builder.HasOne(z => z.Venue)
                .WithMany(v => v.Zones)
                .HasForeignKey(z => z.VenueId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
