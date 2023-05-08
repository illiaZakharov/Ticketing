using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingDomain.Data.Entities;

namespace TicketingDomain.Data.TypeBuilders
{
    internal class RowSeatTypeBuilder : BaseTypeBuilder<RowSeat>
    {
        internal override void Configure(EntityTypeBuilder<RowSeat> builder)
        {
            ConfigureBaseEntity(builder);

            builder.HasOne(e => e.Row)
                .WithMany(u => u.RowSeats)
                .HasForeignKey(e => e.RowId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(e => e.Seat)
                .WithMany(u => u.RowSeats)
                .HasForeignKey(e => e.SeatId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
