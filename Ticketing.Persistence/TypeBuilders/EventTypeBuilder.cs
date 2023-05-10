using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticketing.Persistence.Entities;

namespace Ticketing.Persistence.TypeBuilders
{
    internal class EventTypeBuilder : BaseTypeBuilder<Event>
    {
        internal override void Configure(EntityTypeBuilder<Event> builder)
        {
            ConfigureBaseEntity(builder);

            builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
            builder.Property(e => e.Description).IsRequired(false).HasMaxLength(200);
            builder.Property(e => e.EventDateTime).IsRequired();
            builder.Property(e => e.Duration).IsRequired();
        }
    }
}
