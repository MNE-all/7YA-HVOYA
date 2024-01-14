using _7YA_HVOYA.Context.Contracts.Emuns;
using _7YA_HVOYA.Context.Tests;
using _7YA_HVOYA.Repositories.Contracts;
using _7YA_HVOYA.Repositories.Implementations;
using Xunit;
using FluentAssertions;

namespace _7YA_HVOYA.Repositories.Tests.Tests
{
    public class AccommodationReadRepositoryTests : FamilyHvoyaContextInMemory
    {
        private IAccommodationReadRepository accommodationReadRepository;
        public AccommodationReadRepositoryTests()
        {
            accommodationReadRepository = new AccommodationReadRepository(Reader);
        }

        /// <summary>
        /// Получение размещений по названию склада возвращает данные
        /// </summary>
        [Fact]
        public async Task GetAllByStorageNameShouldReturnValues()
        {
            //Arrange
            var thing1 = TestDataGenerator.Thing(x => x.Category = Categories.Socks);
            var thing2 = TestDataGenerator.Thing(x => x.Category = Categories.Jackets);
            var thing3 = TestDataGenerator.Thing(x => x.Category = Categories.T_shirts);
            var thing4 = TestDataGenerator.Thing(x => x.Category = Categories.Sweatshirts);
            await Context.Things.AddRangeAsync(thing1, thing2, thing3, thing4);

            var target = TestDataGenerator.Storage();
            var storage = TestDataGenerator.Storage();
            await Context.Storages.AddRangeAsync(target, storage);

            var accomodation1 = TestDataGenerator.Accommodation(target, thing1);
            var accomodation2 = TestDataGenerator.Accommodation(target, thing2);
            var accomodation3 = TestDataGenerator.Accommodation(target, thing4);

            var accomodation4 = TestDataGenerator.Accommodation(storage, thing3);
            var accomodation5 = TestDataGenerator.Accommodation(storage, thing4);
            await Context.Accommodations.AddRangeAsync(accomodation1, accomodation2, accomodation3, accomodation4, accomodation5);

            await Context.SaveChangesAsync(CancellationToken);

            // Act
            var result = await accommodationReadRepository.GetAllByStorageNameAsync(target.Name, CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.HaveCount(3)
                .And.ContainSingle(x => x.Id == accomodation1.Id)
                .And.ContainSingle(x => x.Id == accomodation2.Id)
                .And.ContainSingle(x => x.Id == accomodation3.Id);
        }

        /// <summary>
        /// Получение размещений по названию склада возвращает empty
        /// </summary>
        [Fact]
        public async Task GetAllByStorageNameShouldReturnEmpty()
        {
            // Act
            var result = await accommodationReadRepository.GetAllByStorageNameAsync(Guid.NewGuid().ToString(), CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEmpty();
        }

        /// <summary>
        /// Получение размещения по идентификатору возвращает данные
        /// </summary>
        [Fact]
        public async Task GetByIdShouldReturnValue()
        {
            //Arrange
            var thing = TestDataGenerator.Thing();
            var storage = TestDataGenerator.Storage();
            var target = TestDataGenerator.Accommodation(storage, thing);
            await Context.Accommodations.AddAsync(target);
            await Context.SaveChangesAsync(CancellationToken);

            // Act
            var result = await accommodationReadRepository.GetByIdAsync(target.Id, CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEquivalentTo(target);
        }

        /// <summary>
        /// Получение размещениz по идентификатору возвращает null
        /// </summary>
        [Fact]
        public async Task GetByIdShouldReturnNull()
        {
            //Arrange
            var id = Guid.NewGuid();

            // Act
            var result = await accommodationReadRepository.GetByIdAsync(id, CancellationToken);

            // Assert
            result.Should().BeNull();
        }
    }
}
