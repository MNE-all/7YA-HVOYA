using _7YA_HVOYA.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Context.Configuration
{
    public class CartEntityTypeConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart");
            builder.HasIdAsKey();
            builder.PropertyAuditConfiguration();
            builder.Property(x => x.ClientId).IsRequired();
            builder.Property(x => x.ThingId).IsRequired();
            builder.Property(x => x.Amount).IsRequired();

            builder.HasIndex(x => new { x.ClientId, x.ThingId })
                .IsUnique()
                .HasFilter($"{nameof(Cart.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(Cart)}_{nameof(Cart.ClientId)}_{nameof(Cart.ThingId)}");

        }
    }
}
