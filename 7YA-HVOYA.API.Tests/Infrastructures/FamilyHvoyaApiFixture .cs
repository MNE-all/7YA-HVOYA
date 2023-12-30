using Microsoft.EntityFrameworkCore;
using _7YA_HVOYA.Common.Entity.InterfaceDB;
using _7YA_HVOYA.Context;
using _7YA_HVOYA.Context.Contracts;
using Xunit;

namespace _7YA_HVOYA.API.Tests.Infrastructures
{
    public class FamilyHvoyaApiFixture : IAsyncLifetime
    {
        private readonly CustomWebApplicationFactory factory;
        private FamilyHvoyaContext? familyHvoyaContext;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="FamilyHvoyaApiFixture"/>
        /// </summary>
        public FamilyHvoyaApiFixture()
        {
            factory = new CustomWebApplicationFactory();
        }

        Task IAsyncLifetime.InitializeAsync() => FamilyHvoyaContext.Database.MigrateAsync();

        async Task IAsyncLifetime.DisposeAsync()
        {
            await FamilyHvoyaContext.Database.EnsureDeletedAsync();
            await FamilyHvoyaContext.Database.CloseConnectionAsync();
            await FamilyHvoyaContext.DisposeAsync();
            await factory.DisposeAsync();
        }

        public CustomWebApplicationFactory Factory => factory;

        public IFamilyHvoyaContext Context => FamilyHvoyaContext;

        public IUnitOfWork UnitOfWork => FamilyHvoyaContext;

        internal FamilyHvoyaContext FamilyHvoyaContext
        {
            get
            {
                if (familyHvoyaContext != null)
                {
                    return familyHvoyaContext;
                }

                var scope = factory.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
                familyHvoyaContext = scope.ServiceProvider.GetRequiredService<FamilyHvoyaContext>();
                return familyHvoyaContext;
            }
        }
    }
}
