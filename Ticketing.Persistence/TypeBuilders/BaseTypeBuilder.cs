using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticketing.Persistence.Entities;

namespace Ticketing.Persistence.TypeBuilders
{
    internal abstract class BaseTypeBuilder<T> where T : class
    {
        internal abstract void Configure(EntityTypeBuilder<T> builder);

        protected void ConfigureBaseEntity<TEntity>(EntityTypeBuilder<TEntity> builder) where TEntity : BaseEntity
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("uuid_generate_v4()");
            builder.Property(e => e.DateCreated).ValueGeneratedOnAdd().HasDefaultValueSql("(now())").Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            builder.Property(e => e.CreatedBy).ValueGeneratedOnAdd().HasDefaultValueSql("(current_user)");
            builder.Property(e => e.DateModified).ValueGeneratedOnUpdate();
            builder.Property(e => e.ModifiedBy).ValueGeneratedOnUpdate();
            builder.Property(e => e.IsActive).ValueGeneratedOnAdd().HasDefaultValue(true);
        }
    }
}
