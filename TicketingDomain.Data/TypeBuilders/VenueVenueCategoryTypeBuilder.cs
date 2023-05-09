using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingDomain.Data.Entities;

namespace TicketingDomain.Data.TypeBuilders
{
    internal class VenueVenueCategoryTypeBuilder : BaseTypeBuilder<VenueVenueCategory>
    {
        internal override void Configure(EntityTypeBuilder<VenueVenueCategory> builder)
        {
            ConfigureBaseEntity(builder);

            builder.HasOne(e => e.Venue)
                .WithMany(u => u.VenueVenueCategories)
                .HasForeignKey(e => e.VenueId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(e => e.VenueCategory)
                .WithMany(u => u.VenueVenueCategories)
                .HasForeignKey(e => e.VenueCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
