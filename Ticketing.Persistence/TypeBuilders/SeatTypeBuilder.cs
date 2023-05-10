using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticketing.Persistence.Entities;

namespace Ticketing.Persistence.TypeBuilders
{
    internal class SeatTypeBuilder : BaseTypeBuilder<Seat>
    {
        internal override void Configure(EntityTypeBuilder<Seat> builder)
        {
            ConfigureBaseEntity(builder);

            builder.Property(s => s.SeatNumber).IsRequired();
            builder.Property(s => s.RowNumber).IsRequired();
            builder.Property(s => s.ZoneId).IsRequired();

            builder.HasOne(s => s.Zone)
                .WithMany(z => z.Seats)
                .HasForeignKey(s => s.ZoneId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
