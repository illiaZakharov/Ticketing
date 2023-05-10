using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticketing.Persistence.Entities;

namespace Ticketing.Persistence.TypeBuilders
{
    internal class GeneralAdmissionTypeBuilder : BaseTypeBuilder<GeneralAdmission>
    {
        internal override void Configure(EntityTypeBuilder<GeneralAdmission> builder)
        {
            ConfigureBaseEntity(builder);

            builder.Property(ga => ga.MaxQuantity).IsRequired();
            builder.Property(ga => ga.ZoneId).IsRequired();

            builder.HasOne(ga => ga.Zone)
                .WithMany(z => z.GeneralAdmissions)
                .HasForeignKey(ga => ga.ZoneId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
