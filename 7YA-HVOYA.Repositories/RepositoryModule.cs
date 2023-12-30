using Microsoft.Extensions.DependencyInjection;
using _7YA_HVOYA.Common;
using _7YA_HVOYA.Shared;

namespace _7YA_HVOYA.Repositories
{
    public class RepositoryModule : Module
    {
        public override void CreateModule(IServiceCollection service)
        {
            service.AssemblyInterfaceAssignableTo<IRepositoryAnchor>(ServiceLifetime.Scoped);
        }
    }
}
