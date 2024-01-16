using _7YA_HVOYA.Context.Contracts.Models;
using _7YA_HVOYA.Context.Tests;
using _7YA_HVOYA.Repositories.Implementations;
using _7YA_HVOYA.Services.Automappers;
using _7YA_HVOYA.Services.Contracts.Exceptions;
using _7YA_HVOYA.Services.Contracts.Interface;
using _7YA_HVOYA.Services.Implementations;
using AutoMapper;
using FluentAssertions;
using Xunit;

namespace _7YA_HVOYA.Services.Tests.Tests
{

    public class OrderServiceTests : FamilyHvoyaContextInMemory
    {
        private IOrderService orderService;
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="OrderServiceTests"/>
        /// </summary>
        public OrderServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServiceProfile());
            });
            orderService = new OrderService(
                new OrderReadRepository(Reader),
                new OrderWriteRepository(WriterContext),
                UnitOfWork,
                config.CreateMapper()
            );
        }

        /// <summary>
        /// Получение экземпляра заказа по идентификатору возвращает null
        /// </summary>
        [Fact]
        public async Task GetByIdShouldReturnNull()
        {
            //Arrange
            var id = Guid.NewGuid();

            // Act
            Func<Task> act = () => orderService.GetByIdAsync(id, CancellationToken);

            // Assert
            await act.Should().ThrowAsync<FamilyHvoyaEntityNotFoundException<Order>>()
                .WithMessage($"*{id}*");
        }

        /// <summary>
        /// Получение экземпляра заказа по идентификатору возвращает данные
        /// </summary>
        [Fact]
        public async Task GetByIdShouldReturnValue()
        {
            //Arrange
            var client = TestDataGenerator.Client();
            var thing = TestDataGenerator.Thing();
            var target = TestDataGenerator.Order(client, thing);
            await Context.Orders.AddAsync(target);
            await Context.SaveChangesAsync(CancellationToken);

            // Act
            var result = await orderService.GetByIdAsync(target.Id, CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEquivalentTo(new
                {
                    target.Id,
                    target.Client,
                    target.Thing,
                    target.Amount,
                });
        }
    }
}
