using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingDomain.Data.Entities;

namespace TicketingDomain.Data.TypeBuilders
{
    internal class EventCategoryTypeBuilder : BaseTypeBuilder<EventCategory>
    {
        internal override void Configure(EntityTypeBuilder<EventCategory> builder)
        {
            ConfigureBaseEntity(builder);

            builder.Property(e => e.Name).HasMaxLength(200);
            builder.Property(e => e.Description).HasMaxLength(500);
        }
    }
}
