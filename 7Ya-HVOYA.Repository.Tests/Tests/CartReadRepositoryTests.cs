using _7YA_HVOYA.Context.Contracts.Emuns;
using _7YA_HVOYA.Context.Tests;
using _7YA_HVOYA.Repositories.Contracts;
using _7YA_HVOYA.Repositories.Implementations;
using FluentAssertions;
using Xunit;

namespace _7YA_HVOYA.Repositories.Tests.Tests
{
    public class CartReadRepositoryTests : FamilyHvoyaContextInMemory
    {
        private ICartReadRepository cartReadRepository;
        public CartReadRepositoryTests()
        {
            cartReadRepository = new CartReadRepository(Reader);
        }

        /// <summary>
        /// Возвращает пустой список вещей
        /// </summary>
        [Fact]
        public async Task GetAllShouldReturnEmpty()
        {
            // Act
            var result = await cartReadRepository.GetAllAsync(CancellationToken);

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
            var targetClient = TestDataGenerator.Client();
            var thing1 = TestDataGenerator.Thing();
            var thing2 = TestDataGenerator.Thing();
            var target = TestDataGenerator.Cart(targetClient, thing1);
            await Context.Carts.AddRangeAsync(target,
                TestDataGenerator.Cart(targetClient, thing2, x => x.DeletedAt = DateTimeOffset.UtcNow));
            await Context.SaveChangesAsync(CancellationToken);

            // Act
            var result = await cartReadRepository.GetAllAsync(CancellationToken);

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
            var result = await cartReadRepository.GetByIdAsync(id, CancellationToken);

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
            var targetClient = TestDataGenerator.Client();
            var thing = TestDataGenerator.Thing();
            var target = TestDataGenerator.Cart(targetClient, thing);
            await Context.Carts.AddAsync(target);
            await Context.SaveChangesAsync(CancellationToken);

            // Act
            var result = await cartReadRepository.GetByIdAsync(target.Id, CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEquivalentTo(target);
        }

        /// <summary>
        /// Получение вещи по идентификатору возвращает null
        /// </summary>
        [Fact]
        public async Task GetByClientIdShouldReturnNull()
        {
            //Arrange
            var id = Guid.NewGuid();

            // Act
            var result = await cartReadRepository.GetByClientIdAsync(id, CancellationToken);

            // Assert
            result.Should().BeEmpty();
        }

        /// <summary>
        /// Получение вещи по идентификатору возвращает данные
        /// </summary>
        [Fact]
        public async Task GetByClientIdShouldReturnValue()
        {
            //Arrange
            var targetClient = TestDataGenerator.Client();
            var thing1 = TestDataGenerator.Thing();
            var thing2 = TestDataGenerator.Thing();
            var target1 = TestDataGenerator.Cart(targetClient, thing1);
            var target2 = TestDataGenerator.Cart(targetClient, thing2);
            await Context.Carts.AddRangeAsync(target1, target2);
            await Context.SaveChangesAsync(CancellationToken);

            // Act
            var result = await cartReadRepository.GetByClientIdAsync(targetClient.Id, CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.HaveCount(2)
                .And.ContainSingle(x => x.Id == target1.Id)
                .And.ContainSingle(x => x.Id == target2.Id);
        }
    }
}
