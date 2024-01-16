using _7YA_HVOYA.Common.Entity.InterfaceDB;
using _7YA_HVOYA.Context.Contracts.Models;
using _7YA_HVOYA.Context.Tests;
using _7YA_HVOYA.Repositories.Contracts;
using _7YA_HVOYA.Repositories.Implementations;
using _7YA_HVOYA.Services.Automappers;
using _7YA_HVOYA.Services.Contracts.Exceptions;
using _7YA_HVOYA.Services.Contracts.Interface;
using _7YA_HVOYA.Services.Implementations;
using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _7YA_HVOYA.Services.Tests.Tests
{
    public class CartServiceTests : FamilyHvoyaContextInMemory
    {
        private readonly ICartService cartService;
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="CartServiceTests"/>
        /// </summary>
        public CartServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServiceProfile());
            });
            cartService = new CartService(
                new CartReadRepository(Reader),
                new CartWriteRepository(WriterContext),
                UnitOfWork,
                config.CreateMapper()
            );
        }

        /// <summary>
        /// Получение экземпляра корзины по идентификатору возвращает null
        /// </summary>
        [Fact]
        public async Task GetByIdShouldReturnNull()
        {
            //Arrange
            var id = Guid.NewGuid();

            // Act
            Func<Task> act = () => cartService.GetByIdAsync(id, CancellationToken);

            // Assert
            await act.Should().ThrowAsync<FamilyHvoyaEntityNotFoundException<Cart>>()
                .WithMessage($"*{id}*");
        }

        /// <summary>
        /// Получение экземпляра корзины по идентификатору возвращает данные
        /// </summary>
        [Fact]
        public async Task GetByIdShouldReturnValue()
        {
            //Arrange
            var client = TestDataGenerator.Client();
            var thing = TestDataGenerator.Thing();
            var target = TestDataGenerator.Cart(client, thing);
            await Context.Carts.AddAsync(target);
            await Context.SaveChangesAsync(CancellationToken);

            // Act
            var result = await cartService.GetByIdAsync(target.Id, CancellationToken);

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
