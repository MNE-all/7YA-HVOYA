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
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasIdAsKey();
            builder.PropertyAuditConfiguration();
            builder.Property(x => x.Number).IsRequired();
            builder.Property(x => x.ThingId).IsRequired();
            builder.Property(x => x.ClientId).IsRequired();
            builder.Property(x => x.Amount).IsRequired();

            builder.HasIndex(x => new { x.Number, x.ThingId, x.ClientId })
                .IsUnique()
                .HasFilter($"{nameof(Order.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(Order)}_{nameof(Order.Number)}_{nameof(Order.ThingId)}_{nameof(Order.ClientId)}");

        }
    }
}
