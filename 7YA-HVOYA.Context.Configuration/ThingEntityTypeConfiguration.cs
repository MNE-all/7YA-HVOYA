using _7YA_HVOYA.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Context.Configuration
{
    public class ThingEntityTypeConfiguration : IEntityTypeConfiguration<Thing>
    {
        public void Configure(EntityTypeBuilder<Thing> builder)
        {
            builder.ToTable("Thing");
            builder.HasIdAsKey();
            builder.PropertyAuditConfiguration();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Category).IsRequired();
            builder.Property(x => x.Season).IsRequired();
            builder.Property(x => x.Size).IsRequired();
            builder.Property(x => x.Price).IsRequired();

            builder
                .HasMany(x => x.Order)
                .WithOne(x => x.Thing)
                .HasForeignKey(x => x.ThingId);

            builder
               .HasMany(x => x.Accommodation)
               .WithOne(x => x.Thing)
               .HasForeignKey(x => x.ThingId);

            builder
               .HasMany(x => x.Cart)
               .WithOne(x => x.Thing)
               .HasForeignKey(x => x.ThingId);

            builder.HasIndex(x => x.Name)
                .IsUnique()
                .HasFilter($"{nameof(Client.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(Client)}_{nameof(Client.Email)}");
        }
    }
}
