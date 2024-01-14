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
    public class ThingServiceTest : FamilyHvoyaContextInMemory
    {
        private readonly IThingService thingService;

        public ThingServiceTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServiceProfile());
            });
            thingService = new ThingService(
                new ThingReadRepository(Reader),
                new ThingWriteRepository(WriterContext),
                UnitOfWork,
                config.CreateMapper()
            );
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
            Func<Task> act = () => thingService.GetByIdAsync(id, CancellationToken);

            // Assert
            await act.Should().ThrowAsync<FamilyHvoyaEntityNotFoundException<Thing>>()
                .WithMessage($"*{id}*");
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
            var result = await thingService.GetByIdAsync(target.Id, CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEquivalentTo(new
                {
                    target.Id,
                    target.Name,
                    target.Category,
                    target.Size,
                    target.Season,
                    target.Gender,
                    target.Price,
                    target.ImgURL
                });
        }

        /// <summary>
        /// Успешное удаление вещи по идентификатору 
        /// </summary>
        [Fact]
        public async Task DeleteShouldWork()
        {
            //Arrange
            var target = TestDataGenerator.Thing();
            await Context.Things.AddAsync(target);
            await UnitOfWork.SaveChangesAsync(CancellationToken);

            // Act
            Func<Task> act = () => thingService.DeleteAsync(target.Id, CancellationToken);

            // Assert
            await act.Should().NotThrowAsync();
            var entity = Context.Things.Single(x => x.Id == target.Id);
            entity.Should().NotBeNull();
            entity.DeletedAt.Should().NotBeNull();
        }
    }
}
