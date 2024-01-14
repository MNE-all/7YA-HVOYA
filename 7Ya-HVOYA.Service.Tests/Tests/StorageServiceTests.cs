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
    /// <summary>
    /// Тесты для <see cref="IStorageService"/>
    /// </summary>
    public class StorageServiceTests : FamilyHvoyaContextInMemory
    {
        private readonly IStorageService storageService;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="StorageServiceTests"/>
        /// </summary>
        public StorageServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServiceProfile());
            });
            storageService = new StorageService(
                new StorageReadRepository(Reader),
                new StorageWriteRepository(WriterContext),
                UnitOfWork,
                config.CreateMapper());
        }

        /// <summary>
        /// Получение склада по идентификатору возвращает null
        /// </summary>
        [Fact]
        public async Task GetByIdShouldReturnNull()
        {
            //Arrange
            var id = Guid.NewGuid();

            // Act
            Func<Task> act = () => storageService.GetByIdAsync(id, CancellationToken);

            // Assert
            await act.Should().ThrowAsync<FamilyHvoyaEntityNotFoundException<Storage>>()
                .WithMessage($"*{id}*");
        }

        /// <summary>
        /// Получение склада по идентификатору возвращает данные
        /// </summary>
        [Fact]
        public async Task GetByIdShouldReturnValue()
        {
            //Arrange
            var target = TestDataGenerator.Storage();
            await Context.Storages.AddAsync(target);
            await Context.SaveChangesAsync(CancellationToken);

            // Act
            var result = await storageService.GetByIdAsync(target.Id, CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEquivalentTo(new
                {
                    target.Id,
                    target.Name,
                    target.Address,
                });
        }

        /// <summary>
        /// Успешное удаление склада по идентификатору 
        /// </summary>
        [Fact]
        public async Task DeleteShouldWork()
        {
            //Arrange
            var target = TestDataGenerator.Storage();
            await Context.Storages.AddAsync(target);
            await UnitOfWork.SaveChangesAsync(CancellationToken);

            // Act
            Func<Task> act = () => storageService.DeleteAsync(target.Id, CancellationToken);

            // Assert
            await act.Should().NotThrowAsync();
            var entity = Context.Storages.Single(x => x.Id == target.Id);
            entity.Should().NotBeNull();
            entity.DeletedAt.Should().NotBeNull();
        }
    }
}
