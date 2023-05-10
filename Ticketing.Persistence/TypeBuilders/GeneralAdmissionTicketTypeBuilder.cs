using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticketing.Persistence.Entities;

namespace Ticketing.Persistence.TypeBuilders
{
    internal class GeneralAdmissionTicketTypeBuilder : BaseTypeBuilder<GeneralAdmissionTicket>
    {
        internal override void Configure(EntityTypeBuilder<GeneralAdmissionTicket> builder)
        {
            ConfigureBaseEntity(builder);

            builder.Property(gat => gat.Price).IsRequired();
            builder.Property(gat => gat.Status).IsRequired().HasMaxLength(50);
            builder.Property(gat => gat.GeneralAdmissionId).IsRequired();
            builder.Property(gat => gat.OfferId).IsRequired();

            builder.HasOne(gat => gat.GeneralAdmission)
                .WithMany(ga => ga.Tickets)
                .HasForeignKey(gat => gat.GeneralAdmissionId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(gat => gat.Offer)
                .WithMany(o => o.GeneralAdmissionTickets)
                .HasForeignKey(gat => gat.OfferId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
