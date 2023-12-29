using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace _7YA_HVOYA.Context
{
    /// <summary>
    /// Файбрика для создания контекста в DesignTime (Миграции)
    /// </summary>
    public class SampleContextFactory : IDesignTimeDbContextFactory<FamilyHvoyaContext>
    {
        public FamilyHvoyaContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var options = new DbContextOptionsBuilder<FamilyHvoyaContext>()
                .UseSqlServer(connectionString)
                .Options;

            return new FamilyHvoyaContext(options);
        }
    }
}
