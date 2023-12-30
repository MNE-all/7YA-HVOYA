using Xunit;

namespace _7YA_HVOYA.API.Tests.Infrastructures
{
    [CollectionDefinition(nameof(FamilyHvoyaApiTestCollection))]
    public class FamilyHvoyaApiTestCollection
        : ICollectionFixture<FamilyHvoyaApiFixture>
    {
    }
}
