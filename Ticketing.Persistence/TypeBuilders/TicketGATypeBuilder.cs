using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticketing.Persistence.Entities;

namespace Ticketing.Persistence.TypeBuilders
{
    internal class TicketGATypeBuilder : BaseTypeBuilder<TicketGA>
    {
        internal override void Configure(EntityTypeBuilder<TicketGA> builder)
        {
            ConfigureBaseEntity(builder);

            builder.Property(tga => tga.Price).IsRequired();
            builder.Property(tga => tga.Status).IsRequired().HasMaxLength(50);
            builder.Property(tga => tga.GeneralAdmissionId).IsRequired();

            builder.HasOne(tga => tga.GeneralAdmission)
                .WithMany(ga => ga.Tickets)
                .HasForeignKey(tga => tga.GeneralAdmissionId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
