using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticketing.Persistence.Entities;

namespace Ticketing.Persistence.TypeBuilders
{
    internal class OfferTypeBuilder : BaseTypeBuilder<Offer>
    {
        internal override void Configure(EntityTypeBuilder<Offer> builder)
        {
            ConfigureBaseEntity(builder);

            builder.Property(o => o.StartDate).IsRequired();
            builder.Property(o => o.EndDate).IsRequired();
            builder.Property(o => o.VenueId).IsRequired();
            builder.Property(o => o.EventId).IsRequired();

            builder.HasOne(o => o.Venue)
                .WithMany(v => v.Offers)
                .HasForeignKey(o => o.VenueId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(o => o.Event)
                .WithOne(e => e.Offer)
                .HasForeignKey<Offer>(o => o.EventId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
