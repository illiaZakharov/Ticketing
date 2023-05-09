using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingDomain.Data.Entities;

namespace TicketingDomain.Data.TypeBuilders
{
    internal class RowTypeBuilder : BaseTypeBuilder<Row>
    {
        internal override void Configure(EntityTypeBuilder<Row> builder)
        {
            ConfigureBaseEntity(builder);

            builder.Property(v => v.Name).IsRequired().HasMaxLength(200);
            builder.Property(v => v.Description).IsRequired(false).HasMaxLength(500);
        }
    }
}
