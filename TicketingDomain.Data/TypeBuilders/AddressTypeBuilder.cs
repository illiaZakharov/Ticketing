using TicketingDomain.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace TicketingDomain.Data.TypeBuilders
{
    internal class AddressTypeBuilder : BaseTypeBuilder<Address>
    {
        internal override void Configure(EntityTypeBuilder<Address> builder)
        {
            ConfigureBaseEntity(builder);

            builder.Property(a => a.Name).IsRequired(false).HasMaxLength(200);
            builder.Property(a => a.Country).IsRequired().HasMaxLength(50);
            builder.Property(a => a.City).IsRequired().HasMaxLength(50);
            builder.Property(a => a.AddressLine).IsRequired().HasMaxLength(200);

            builder.HasOne(a => a.Venue)
                .WithOne(v => v.Location)
                .HasForeignKey<Venue>(v => v.LocationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
