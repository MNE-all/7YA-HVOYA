using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using _7YA_HVOYA.Common;
using _7YA_HVOYA.Common.Entity.InterfaceDB;
using _7YA_HVOYA.Context.Contracts;

namespace _7YA_HVOYA.Context
{
    public class ContextModule : Module
    {
        public override void CreateModule(IServiceCollection service)
        {
            service.TryAddScoped<IFamilyHvoyaContext>(provider => provider.GetRequiredService<FamilyHvoyaContext>());
            service.TryAddScoped<IDbRead>(provider => provider.GetRequiredService<FamilyHvoyaContext>());
            service.TryAddScoped<IDbWriter>(provider => provider.GetRequiredService<FamilyHvoyaContext>());
            service.TryAddScoped<IUnitOfWork>(provider => provider.GetRequiredService<FamilyHvoyaContext>());
        }
    }
}
