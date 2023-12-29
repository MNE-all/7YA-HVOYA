using _7YA_HVOYA.Common.Entity.InterfaceDB;
using _7YA_HVOYA.Context.Contracts;
using _7YA_HVOYA.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace _7YA_HVOYA.Context
{
    /// <summary>
    /// Контекст работы с БД
    /// </summary>
    /// <remarks>
    /// 1) dotnet tool install --global dotnet-ef
    /// 2) dotnet tool update --global dotnet-ef
    /// 3) dotnet ef migrations add [name] --project TimeTable203.Context\TimeTable203.Context.csproj
    /// 4) dotnet ef database update --project TimeTable203.Context\TimeTable203.Context.csproj
    /// 5) dotnet ef database update [targetMigrationName] --TimeTable203.Context\TimeTable203.Context.csproj
    /// </remarks>
    public class FamilyHvoyaContext : DbContext,
        IFamilyHvoyaContext,
        IDbRead,
        IDbWriter,
        IUnitOfWork
    {
        public DbSet<Thing> Things { get; set; }

        public DbSet<Storage> Storages { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Accommodation> Accommodations { get; set; }

        public DbSet<Order> Orders { get; set; }

        public FamilyHvoyaContext(DbContextOptions<FamilyHvoyaContext> options) : base (options)
        {
            Log.Information("Инициализирована бд");
        }

        void IDbWriter.Add<TEntity>(TEntity entity) => base.Entry(entity).State = EntityState.Added;

        void IDbWriter.Delete<TEntity>(TEntity entity) => base.Entry(entity).State = EntityState.Deleted;

        IQueryable<TEntity> IDbRead.Read<TEntity>() => base.Set<TEntity>()
                .AsNoTracking()
                .AsQueryable();

        void IDbWriter.Update<TEntity>(TEntity entity) => base.Entry(entity).State = EntityState.Modified;


        async Task<int> IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken)
        {
            Log.Information("Идет сохранение данных в бд");
            var count = await base.SaveChangesAsync(cancellationToken);
            SkipTracker();
            return count;
        }

        public void SkipTracker()
        {
            foreach (var entry in base.ChangeTracker.Entries().ToArray())
            {
                entry.State = EntityState.Detached;
            }
        }
    }
}
