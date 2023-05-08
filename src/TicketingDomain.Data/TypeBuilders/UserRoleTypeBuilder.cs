﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingDomain.Data.Entities;

namespace TicketingDomain.Data.TypeBuilders
{
    internal class UserRoleTypeBuilder : BaseTypeBuilder<UserRole>
    {
        internal override void Configure(EntityTypeBuilder<UserRole> builder)
        {
            ConfigureBaseEntity(builder);

            builder.Property(r => r.Name).IsRequired().HasMaxLength(50);
            builder.Property(r => r.Description).HasMaxLength(500);
        }
    }
}
