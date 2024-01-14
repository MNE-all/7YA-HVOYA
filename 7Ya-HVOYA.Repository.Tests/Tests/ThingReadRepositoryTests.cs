using _7YA_HVOYA.Context.Contracts.Emuns;
using _7YA_HVOYA.Context.Tests;
using _7YA_HVOYA.Repositories.Contracts;
using _7YA_HVOYA.Repositories.Implementations;
using FluentAssertions;
using Xunit;

namespace _7YA_HVOYA.Repositories.Tests.Tests
{
    public class ThingReadRepositoryTests : FamilyHvoyaContextInMemory
    {
        private readonly IThingReadRepository thingReadRepository;

        public ThingReadRepositoryTests()
        {
            thingReadRepository = new ThingReadRepository(Reader);
        }

        /// <summary>
        /// Возвращает пустой список вещей
        /// </summary>
        [Fact]
        public async Task GetAllShouldReturnEmpty()
        {
            // Act
            var result = await thingReadRepository.GetAllAsync(CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEmpty();
        }

        /// <summary>
        /// Возвращает список вещей
        /// </summary>
        [Fact]
        public async Task GetAllShouldReturnValues()
        {
            //Arrange
            var target = TestDataGenerator.Thing();
            await Context.Things.AddRangeAsync(target,
                TestDataGenerator.Thing(x => x.DeletedAt = DateTimeOffset.UtcNow));
            await Context.SaveChangesAsync(CancellationToken);

            // Act
            var result = await thingReadRepository.GetAllAsync(CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.HaveCount(1)
                .And.ContainSingle(x => x.Id == target.Id);
        }


        /// <summary>
        /// Получение вещи по идентификатору возвращает null
        /// </summary>
        [Fact]
        public async Task GetByIdShouldReturnNull()
        {
            //Arrange
            var id = Guid.NewGuid();

            // Act
            var result = await thingReadRepository.GetByIdAsync(id, CancellationToken);

            // Assert
            result.Should().BeNull();
        }

        /// <summary>
        /// Получение вещи по идентификатору возвращает данные
        /// </summary>
        [Fact]
        public async Task GetByIdShouldReturnValue()
        {
            //Arrange
            var target = TestDataGenerator.Thing();
            await Context.Things.AddAsync(target);
            await Context.SaveChangesAsync(CancellationToken);

            // Act
            var result = await thingReadRepository.GetByIdAsync(target.Id, CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEquivalentTo(target);
        }


        /// <summary>
        /// Получение списка вещей по идентификаторам возвращает пустую коллекцию
        /// </summary>
        [Fact]
        public async Task GetByIdsShouldReturnEmpty()
        {
            //Arrange
            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var id3 = Guid.NewGuid();

            // Act
            var result = await thingReadRepository.GetByIdsAsync(new[] { id1, id2, id3 }, CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEmpty();
        }


        /// <summary>
        /// Получение списка вещей по идентификаторам возвращает данные
        /// </summary>
        [Fact]
        public async Task GetByIdsShouldReturnValue()
        {
            //Arrange
            var target1 = TestDataGenerator.Thing();
            var target2 = TestDataGenerator.Thing(x => x.DeletedAt = DateTimeOffset.UtcNow);
            var target3 = TestDataGenerator.Thing();
            var target4 = TestDataGenerator.Thing();
            await Context.Things.AddRangeAsync(target1, target2, target3, target4);
            await Context.SaveChangesAsync(CancellationToken);

            // Act
            var result = await thingReadRepository.GetByIdsAsync(new[] { target1.Id, target2.Id, target4.Id }, CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.HaveCount(2)
                .And.ContainKey(target1.Id)
                .And.ContainKey(target4.Id);
        }


        /// <summary>
        /// Получение вещей по категории возвращает пустую коллекцию
        /// </summary>
        [Fact]
        public async Task GetAllByCategoryShouldReturnNull()
        {
            //Arrange
            var categoryTShirts = Categories.T_shirts;

            // Act
            var result = await thingReadRepository.GetAllByCategoryAsync(categoryTShirts, CancellationToken);

            // Assert
            result.Should().BeEmpty();
        }

        /// <summary>
        /// Получение вещей по категории возвращает данные
        /// </summary>
        [Fact]
        public async Task GetAllByCategoryShouldReturnValues()
        {
            //Arrange
            var target1 = TestDataGenerator.Thing(x => x.Category = Categories.Socks);
            var target2 = TestDataGenerator.Thing(x => x.Category = Categories.Jackets);
            var target3 = TestDataGenerator.Thing(x => x.DeletedAt = DateTimeOffset.UtcNow);
            target3.Category = Categories.Socks;
            var target4 = TestDataGenerator.Thing(x => x.Category = Categories.Socks);
            await Context.Things.AddRangeAsync(target1, target2, target3, target4);
            await Context.SaveChangesAsync(CancellationToken);

            // Act
            var result = await thingReadRepository.GetAllByCategoryAsync(Categories.Socks, CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.HaveCount(2)
                .And.ContainSingle(x => x.Id == target1.Id)
                .And.ContainSingle(x => x.Id == target4.Id);
        }
    }
}
