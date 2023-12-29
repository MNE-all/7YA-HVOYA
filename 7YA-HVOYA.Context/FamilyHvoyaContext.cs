using _7YA_HVOYA.Common.Entity.InterfaceDB;
using _7YA_HVOYA.Context.Contracts;
using _7YA_HVOYA.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    internal class FamilyHvoyaContext : DbContext,
        IFamilyHvoyaContext,
        IDbRead,
        IDbWriter,
        IUnitOfWork
    {
        public DbSet<Thing> Things => throw new NotImplementedException();

        public DbSet<Storage> Storages => throw new NotImplementedException();

        public DbSet<Client> Clients => throw new NotImplementedException();

        public DbSet<Cart> Carts => throw new NotImplementedException();

        public DbSet<Accommodation> Accommodations => throw new NotImplementedException();

        public DbSet<Order> Orders => throw new NotImplementedException();

        void IDbWriter.Add<TEntity>(TEntity entity) => base.Entry(entity).State = EntityState.Added;

        void IDbWriter.Delete<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        IQueryable<TEntity> IDbRead.Read<TEntity>() => base.Set<TEntity>()
                .AsNoTracking()
                .AsQueryable();

        void IDbWriter.Update<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
