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
    public class AccommodationEntityTypeConfiguration : IEntityTypeConfiguration<Accommodation>
    {
        public void Configure(EntityTypeBuilder<Accommodation> builder)
        {
            builder.ToTable("Accommodation");
            builder.HasIdAsKey();
            builder.PropertyAuditConfiguration();
            builder.Property(x => x.ThingId).IsRequired();
            builder.Property(x => x.StorageId).IsRequired();
            builder.Property(x => x.Amount).IsRequired();

            builder.HasIndex(x => new { x.ThingId, x.StorageId })
               .IsUnique()
               .HasFilter($"{nameof(Accommodation.DeletedAt)} is null")
               .HasDatabaseName($"IX_{nameof(Accommodation)}_{nameof(Accommodation.ThingId)}_{nameof(Accommodation.StorageId)}");

        }
    }
}
