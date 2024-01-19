using _7YA_HVOYA.API.Models;
using _7YA_HVOYA.API.Tests.Infrastructures;
using _7YA_HVOYA.Common.Entity.InterfaceDB;
using _7YA_HVOYA.Context.Contracts;
using _7YA_HVOYA.Context.Contracts.Emuns;
using _7YA_HVOYA.Context.Contracts.Models;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace _7YA_HVOYA.API.Tests
{
    [Collection(nameof(FamilyHvoyaApiTestCollection))]
    public class FirstIntergTests
    {
        private readonly CustomWebApplicationFactory factory;
        private readonly IFamilyHvoyaContext context;
        private readonly IUnitOfWork unitOfWork;

        public FirstIntergTests(FamilyHvoyaApiFixture fixture)
        {
            factory = fixture.Factory;
            context = fixture.Context;
            unitOfWork = fixture.UnitOfWork;
        }


        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public async Task GetValue()
        {
            // Arrange
            var client = factory.CreateClient();
            Random random = new Random();

            Array valuesCategories = Enum.GetValues(typeof(Categories));
            Categories randomCategory = (Categories)valuesCategories
                .GetValue(random.Next(valuesCategories.Length));

            Array valuesGenders = Enum.GetValues(typeof(Genders));
            Genders randomGender = (Genders)valuesGenders
                .GetValue(random.Next(valuesGenders.Length));

            Array valuesSizes = Enum.GetValues(typeof(Sizes));
            Sizes randomSize = (Sizes)valuesSizes
                .GetValue(random.Next(valuesSizes.Length));

            Array valuesSeasons = Enum.GetValues(typeof(Seasons));
            Seasons randomSeason = (Seasons)valuesSeasons
                .GetValue(random.Next(valuesSeasons.Length));



            var targetItem = new Thing
            {
                Id = Guid.NewGuid(),
                Name = $"Name{new Random().Next(9999)}",
                Category = randomCategory,
                Gender = randomGender,
                Size = randomSize,
                Season = randomSeason,
                Price = random.Next(500, 10000),
                ImgURL = $"ImgURL{Guid.NewGuid():N}",

                CreatedAt = DateTime.UtcNow,
                CreatedBy = $"CreatedBy{Guid.NewGuid():N}",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = $"UpdatedBy{Guid.NewGuid():N}",
            };
            await context.Things.AddAsync(targetItem);
            await unitOfWork.SaveChangesAsync();

            // Act
            var response = await client.GetAsync("/Thing");

            // Assert
            response.EnsureSuccessStatusCode();
            var resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<IEnumerable<ThingResponse>>(resultString);
            result.Should().NotBeNull()
                .And.ContainSingle(x => x.Id == targetItem.Id);
        }
    }
}
