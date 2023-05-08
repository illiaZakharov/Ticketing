using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingDomain.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace TicketingDomain.Data.TypeBuilders
{
    internal class UserTypeBuilder : BaseTypeBuilder<User>
    {
        internal override void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigureBaseEntity(builder);

            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.EmailAddress).IsRequired().HasMaxLength(200);
            builder.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(30);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(200);

            builder.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(p => p.Ticket)
                .WithOne(t => t.User)
                .HasForeignKey<Ticket>(t => t.PaymentId);
        }
    }
}
