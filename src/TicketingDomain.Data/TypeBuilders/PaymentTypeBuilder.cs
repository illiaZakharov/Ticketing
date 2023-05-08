using TicketingDomain.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketingDomain.Data.TypeBuilders
{
    internal class PaymentTypeBuilder : BaseTypeBuilder<Payment>
    {
        internal override void Configure(EntityTypeBuilder<Payment> builder)
        {
            ConfigureBaseEntity(builder);

            builder.Property(p => p.Amount).IsRequired();
            builder.Property(p => p.Method).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Status).IsRequired().HasMaxLength(50);

            builder.HasOne(p => p.Ticket)
                .WithOne(t => t.Payment)
                .HasForeignKey<Ticket>(t => t.PaymentId);
        }
    }
}
