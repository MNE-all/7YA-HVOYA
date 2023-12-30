using _7YA_HVOYA.API.Infrastructures.Validator;
using _7YA_HVOYA.Common;
using _7YA_HVOYA.Common.Entity.InterfaceDB;
using _7YA_HVOYA.Context;
using _7YA_HVOYA.Repositories;
using _7YA_HVOYA.Services;
using _7YA_HVOYA.Shared;

namespace _7YA_HVOYA.API.Infrastructures
{
    static internal class ServiceCollectionExtensions
    {
        public static void AddDependencies(this IServiceCollection service)
        {
            service.AddTransient<IDateTimeProvider, DateTimeProvider>();
            service.AddTransient<IDbWriterContext, DbWriterContext>();
            service.AddTransient<IApiValidatorService, ApiValidatorService>();
            service.RegisterAutoMapperProfile<ApiAutoMapperProfile>();

            service.RegisterModule<ServiceModule>();
            service.RegisterModule<RepositoryModule>();
            service.RegisterModule<ContextModule>();

            service.RegisterAutoMapper();
        }
    }
}
