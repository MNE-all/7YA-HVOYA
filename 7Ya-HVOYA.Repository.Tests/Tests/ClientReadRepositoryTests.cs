using _7YA_HVOYA.Context.Tests;
using _7YA_HVOYA.Repositories.Contracts;
using _7YA_HVOYA.Repositories.Implementations;
using FluentAssertions;
using Xunit;

namespace _7YA_HVOYA.Repositories.Tests.Tests
{
    public class ClientReadRepositoryTests : FamilyHvoyaContextInMemory
    {
        private IClientReadRepository clientReadRepository;

        public ClientReadRepositoryTests()
        {
            clientReadRepository = new ClientReadRepository(Reader);
        }

        /// <summary>
        /// Возвращает пустой список пользователей
        /// </summary>
        [Fact]
        public async Task GetAllShouldReturnEmpty()
        {
            // Act
            var result = await clientReadRepository.GetAllAsync(CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEmpty();
        }

        /// <summary>
        /// Возвращает список пользователей
        /// </summary>
        [Fact]
        public async Task GetAllShouldReturnValues()
        {
            //Arrange
            var target = TestDataGenerator.Client();
            await Context.Clients.AddRangeAsync(target,
                TestDataGenerator.Client(x => x.DeletedAt = DateTimeOffset.UtcNow));
            await Context.SaveChangesAsync(CancellationToken);

            // Act
            var result = await clientReadRepository.GetAllAsync(CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.HaveCount(1)
                .And.ContainSingle(x => x.Id == target.Id);
        }


        /// <summary>
        /// Получение пользователя по идентификатору возвращает null
        /// </summary>
        [Fact]
        public async Task GetByIdShouldReturnNull()
        {
            //Arrange
            var id = Guid.NewGuid();

            // Act
            var result = await clientReadRepository.GetByIdAsync(id, CancellationToken);

            // Assert
            result.Should().BeNull();
        }

        /// <summary>
        /// Получение пользователя по идентификатору возвращает данные
        /// </summary>
        [Fact]
        public async Task GetByIdShouldReturnValue()
        {
            //Arrange
            var target = TestDataGenerator.Client();
            await Context.Clients.AddAsync(target);
            await Context.SaveChangesAsync(CancellationToken);

            // Act
            var result = await clientReadRepository.GetByIdAsync(target.Id, CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEquivalentTo(target);
        }
    }
}
