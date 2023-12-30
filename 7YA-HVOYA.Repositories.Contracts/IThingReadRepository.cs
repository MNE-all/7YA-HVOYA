using _7YA_HVOYA.Context.Contracts.Emuns;
using _7YA_HVOYA.Context.Contracts.Models;
using System.Text.RegularExpressions;

namespace _7YA_HVOYA.Repositories.Contracts
{
    public interface IThingReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Thing"/>
        /// </summary>
        Task<IReadOnlyCollection<Thing>> GetAllAsync(CancellationToken cancellationToken);
        /// <summary>
        /// Получить список всех <see cref="Thing"/> по <see langword="category"/> и 
        /// </summary>
        Task<IReadOnlyCollection<Thing>> GetAllByCategoryAsync(Categories category, CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Thing"/> по идентификатору
        /// </summary>
        Task<Thing?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
