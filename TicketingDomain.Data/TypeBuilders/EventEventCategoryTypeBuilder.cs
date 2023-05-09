using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingDomain.Data.Entities;

namespace TicketingDomain.Data.TypeBuilders
{
    internal class EventEventCategoryTypeBuilder : BaseTypeBuilder<EventEventCategory>
    {
        internal override void Configure(EntityTypeBuilder<EventEventCategory> builder)
        {
            ConfigureBaseEntity(builder);

            builder.HasOne(e => e.Event)
                .WithMany(u => u.EventEventCategories)
                .HasForeignKey(e => e.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(e => e.EventCategory)
                .WithMany(u => u.EventEventCategories)
                .HasForeignKey(e => e.EventCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
