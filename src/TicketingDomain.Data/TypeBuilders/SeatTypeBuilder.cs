using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingDomain.Data.Entities;

namespace TicketingDomain.Data.TypeBuilders
{
    internal class SeatTypeBuilder : BaseTypeBuilder<Seat>
    {
        internal override void Configure(EntityTypeBuilder<Seat> builder)
        {
            ConfigureBaseEntity(builder);

            builder.Property(v => v.Name).IsRequired(false).HasMaxLength(200);
            builder.Property(v => v.Description).IsRequired(false).HasMaxLength(500);
            builder.Property(v => v.Status).IsRequired().HasMaxLength(200);
            builder.Property(v => v.Type).IsRequired().HasMaxLength(200);

            builder.HasOne(p => p.Ticket)
                .WithOne(t => t.Seat)
                .HasForeignKey<Ticket>(t => t.PaymentId);
        }
    }
}
