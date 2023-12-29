using _7YA_HVOYA.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _7YA_HVOYA.Context.Configuration
{
    public class ClientEntityTypeConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasIdAsKey();
            builder.PropertyAuditConfiguration();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Password).IsRequired();

            builder
                .HasMany(x => x.Cart)
                .WithOne(x => x.Client)
                .HasForeignKey(x => x.ClientId);

            builder
               .HasMany(x => x.Order)
               .WithOne(x => x.Client)
               .HasForeignKey(x => x.ClientId);


            builder.HasIndex(x => x.Email)
                .IsUnique()
                .HasFilter($"{nameof(Client.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(Client)}_{nameof(Client.Email)}");

            builder.HasIndex(x => x.Phone)
               .IsUnique()
               .HasFilter($"{nameof(Client.DeletedAt)} is null")
               .HasDatabaseName($"IX_{nameof(Client)}_{nameof(Client.Phone)}");
        }
    }
}
