using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingDomain.Data.Entities;

namespace TicketingDomain.Data.TypeBuilders
{
    internal class VenueCategoryTypeBuilder : BaseTypeBuilder<VenueCategory>
    {
        internal override void Configure(EntityTypeBuilder<VenueCategory> builder)
        {
            ConfigureBaseEntity(builder);

            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Description).IsRequired(false).HasMaxLength(500);
        }
    }
}
