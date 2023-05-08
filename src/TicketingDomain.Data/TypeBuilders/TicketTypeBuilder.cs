using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingDomain.Data.Entities;

namespace TicketingDomain.Data.TypeBuilders
{
    internal class TicketTypeBuilder : BaseTypeBuilder<Ticket>
    {
        internal override void Configure(EntityTypeBuilder<Ticket> builder)
        {
            ConfigureBaseEntity(builder);

            builder.Property(t => t.Price).IsRequired();
            builder.Property(t => t.EventId).IsRequired();
            builder.Property(t => t.SeatId).IsRequired();
            builder.Property(t => t.UserId).IsRequired();
            builder.Property(t => t.PaymentId).IsRequired();
        }
    }
}
