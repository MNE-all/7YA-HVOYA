using AutoMapper;
using FluentAssertions;
using _7YA_HVOYA.Context.Tests;
using _7YA_HVOYA.Repositories.Implementations;
using _7YA_HVOYA.Services.Automappers;
using _7YA_HVOYA.Services.Contracts.Interface;
using _7YA_HVOYA.Services.Implementations;
using Xunit;


namespace _7Ya_HVOYA.Service.Tests.Tests
{
    public class ThingServiceTest : FamilyHvoyaContextInMemory
    {
        private readonly IThingService thingService;

        public ThingServiceTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServiceProfile());
            });
            thingService = new GroupService(
                new GroupReadRepository(Reader),
                new GroupWriteRepository(WriterContext),
                UnitOfWork,
                new PersonReadRepository(Reader),
                new EmployeeReadRepository(Reader),
                config.CreateMapper()
            );
        }
    }
}
