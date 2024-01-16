using AutoMapper;
using FluentAssertions;
using _7YA_HVOYA.Context.Tests;
using _7YA_HVOYA.Repositories.Implementations;
using _7YA_HVOYA.Services.Automappers;
using _7YA_HVOYA.Services.Contracts.Interface;
using _7YA_HVOYA.Services.Implementations;
using Xunit;
using _7YA_HVOYA.Services.Contracts.Exceptions;
using _7YA_HVOYA.Context.Contracts.Models;

namespace _7YA_HVOYA.Services.Tests.Tests
{
    public class AccommodationServiceTests : FamilyHvoyaContextInMemory
    {
        private readonly IAccommodationService accommodationService;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="AccommodationServiceTests"/>
        /// </summary>

        public AccommodationServiceTests() 
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServiceProfile());
            });
            accommodationService = new AccommodationService(
                new AccommodationReadRepository(Reader),
                new AccommodationWriteRepository(WriterContext),
                UnitOfWork,
                config.CreateMapper()
            );
        }


        /// <summary>
        /// Получение размещения по идентификатору возвращает null
        /// </summary>
        [Fact]
        public async Task GetByIdShouldReturnNull()
        {
            //Arrange
            var id = Guid.NewGuid();

            // Act
            Func<Task> act = () => accommodationService.GetByIdAsync(id, CancellationToken);

            // Assert
            await act.Should().ThrowAsync<FamilyHvoyaEntityNotFoundException<Accommodation>>()
                .WithMessage($"*{id}*");
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
            var result = await accommodationService.GetByIdAsync(target.Id, CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEquivalentTo(new
                {
                    target.Id,
                    target.Thing,
                    target.Storage,
                    target.Amount,
                });
        }
    }
}
