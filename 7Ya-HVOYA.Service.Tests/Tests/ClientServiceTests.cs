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
    public class ClientServiceTests : FamilyHvoyaContextInMemory
    {
        private readonly IClientService clientService;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ClientServiceTests"/>
        /// </summary>

        public ClientServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServiceProfile());
            });
            clientService = new ClientService(
                new ClientReadRepository(Reader),
                new ClientWriteRepository(WriterContext),
                UnitOfWork,
                config.CreateMapper()
            );
        }

        /// <summary>
        /// Получение клиента по идентификатору возвращает null
        /// </summary>
        [Fact]
        public async Task GetByIdShouldReturnNull()
        {
            //Arrange
            var id = Guid.NewGuid();

            // Act
            Func<Task> act = () => clientService.GetByIdAsync(id, CancellationToken);

            // Assert
            await act.Should().ThrowAsync<FamilyHvoyaEntityNotFoundException<Client>>()
                .WithMessage($"*{id}*");
        }

        /// <summary>
        /// Получение клиента по идентификатору возвращает данные
        /// </summary>
        [Fact]
        public async Task GetByIdShouldReturnValue()
        {
            //Arrange
            var target = TestDataGenerator.Client();
            await Context.Clients.AddAsync(target);
            await Context.SaveChangesAsync(CancellationToken);

            // Act
            var result = await clientService.GetByIdAsync(target.Id, CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEquivalentTo(new
                {
                    target.Id,
                    target.Surname,
                    target.Name,
                    target.Patronymic,
                    target.Birthday,
                    target.Gender,
                    target.Password,
                    target.Email,
                    target.Phone,
                });
        }
    }
}
