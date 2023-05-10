using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticketing.Persistence.Entities;

namespace Ticketing.Persistence.TypeBuilders
{
    internal class TicketSTypeBuilder : BaseTypeBuilder<TicketS>
    {
        internal override void Configure(EntityTypeBuilder<TicketS> builder)
        {
            ConfigureBaseEntity(builder);

            builder.Property(ts => ts.Price).IsRequired();
            builder.Property(ts => ts.Status).IsRequired().HasMaxLength(50);
            builder.Property(ts => ts.SeatId).IsRequired();

            builder.HasOne(ts => ts.Seat)
                .WithOne(s => s.Ticket)
                .HasForeignKey<TicketS>(ts => ts.SeatId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
