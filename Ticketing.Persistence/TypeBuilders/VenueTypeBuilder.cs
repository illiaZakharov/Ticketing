using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticketing.Persistence.Entities;

namespace Ticketing.Persistence.TypeBuilders
{
    internal class VenueTypeBuilder : BaseTypeBuilder<Venue>
    {
        internal override void Configure(EntityTypeBuilder<Venue> builder)
        {
            ConfigureBaseEntity(builder);

            builder.Property(v => v.Name).IsRequired().HasMaxLength(200);
            builder.Property(v => v.Description).IsRequired(false).HasMaxLength(500);
        }
    }
}
