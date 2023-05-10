using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticketing.Persistence.Entities;

namespace Ticketing.Persistence.TypeBuilders
{
    internal class SeatTicketTypeBuilder : BaseTypeBuilder<SeatTicket>
    {
        internal override void Configure(EntityTypeBuilder<SeatTicket> builder)
        {
            ConfigureBaseEntity(builder);

            builder.Property(st => st.Price).IsRequired();
            builder.Property(st => st.Status).IsRequired().HasMaxLength(50);
            builder.Property(st => st.SeatId).IsRequired();
            builder.Property(st => st.OfferId).IsRequired();

            builder.HasOne(st => st.Seat)
                .WithOne(s => s.Ticket)
                .HasForeignKey<SeatTicket>(st => st.SeatId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(st => st.Offer)
                .WithMany(o => o.SeatTickets)
                .HasForeignKey(st => st.OfferId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
