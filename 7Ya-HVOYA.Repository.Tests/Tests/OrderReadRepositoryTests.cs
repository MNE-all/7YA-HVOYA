using _7YA_HVOYA.Context.Tests;
using _7YA_HVOYA.Repositories.Contracts;
using _7YA_HVOYA.Repositories.Implementations;
using Xunit;
using FluentAssertions;
using _7YA_HVOYA.Context.Contracts.Emuns;

namespace _7YA_HVOYA.Repositories.Tests.Tests
{
    public class OrderReadRepositoryTests : FamilyHvoyaContextInMemory
    {
        IOrderReadRepository orderReadRepository;
        public OrderReadRepositoryTests()
        {
            orderReadRepository = new OrderReadRepository(Reader);
        }

        /// <summary>
        /// Возвращает пустой список заказанных вещей
        /// </summary>
        [Fact]
        public async Task GetAllShouldReturnEmpty()
        {
            // Act
            var result = await orderReadRepository.GetAllAsync(CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEmpty();
        }

        /// <summary>
        /// Возвращает список заказанных вещей
        /// </summary>
        [Fact]
        public async Task GetAllShouldReturnValues()
        {
            //Arrange
            var client = TestDataGenerator.Client();
            var thing1 = TestDataGenerator.Thing();
            var thing2 = TestDataGenerator.Thing();
            var target = TestDataGenerator.Order(client, thing1, -2);
            await Context.Orders.AddRangeAsync(target,
                TestDataGenerator.Order(client, thing2, -2, x => x.DeletedAt = DateTimeOffset.UtcNow));
            await Context.SaveChangesAsync(CancellationToken);

            // Act
            var result = await orderReadRepository.GetAllAsync(CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.HaveCount(1)
                .And.ContainSingle(x => x.Id == target.Id);
        }


        /// <summary>
        /// Получение список заказанных вещей по идентификатору пользователя возвращает null
        /// </summary>
        [Fact]
        public async Task GetByClientIdShouldReturnEmpty()
        {
            //Arrange
            var id = Guid.NewGuid();

            // Act
            var result = await orderReadRepository.GetByClientIdAsync(id, CancellationToken);

            // Assert
            result.Should().BeEmpty();
        }

        /// <summary>
        /// Получение списка заказанных вещей идентификатору пользователя возвращает данные
        /// </summary>
        [Fact]
        public async Task GetByClientIdShouldReturnValue()
        {
            //Arrange
            var thing1 = TestDataGenerator.Thing();
            var thing2 = TestDataGenerator.Thing();
            var client = TestDataGenerator.Client();
            var target1 = TestDataGenerator.Order(client, thing1, 1);
            var target2 = TestDataGenerator.Order(client, thing2, 1);
            await Context.Orders.AddRangeAsync(target1, target2);
            await Context.SaveChangesAsync(CancellationToken);

            // Act
            var result = await orderReadRepository.GetByClientIdAsync(client.Id, CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.HaveCount(2)
                .And.ContainSingle(x => x.Id == target1.Id && x.ClientId == client.Id)
                .And.ContainSingle(x => x.Id == target2.Id && x.ClientId == client.Id);
        }


        /// <summary>
        /// Получение списка заказанных вещей по идентификаторам возвращает пустую коллекцию
        /// </summary>
        [Fact]
        public async Task GetByNumberShouldReturnEmpty()
        {
            //Arrange
            var number = -1;
            // Act
            var result = await orderReadRepository.GetByNumberAsync(number, CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEmpty();
        }


        /// <summary>
        /// Получение списка вещей по идентификаторам возвращает данные
        /// </summary>
        [Fact]
        public async Task GetByNumberShouldReturnValue()
        {
            //Arrange
            var number = -4;
            var thing1 = TestDataGenerator.Thing();
            var thing2 = TestDataGenerator.Thing();
            var client = TestDataGenerator.Client();
            var target1 = TestDataGenerator.Order(client, thing1, number);
            var target2 = TestDataGenerator.Order(client, thing2, number);
            await Context.Orders.AddRangeAsync(target1, target2);
            await Context.SaveChangesAsync(CancellationToken);

            // Act
            var result = await orderReadRepository.GetByNumberAsync(number, CancellationToken);

            // Assert
            // Assert
            result.Should()
                .NotBeNull()
                .And.HaveCount(2)
                .And.ContainSingle(x => x.Id == target1.Id && x.ClientId == client.Id)
                .And.ContainSingle(x => x.Id == target2.Id && x.ClientId == client.Id);
        }
    }
}
