using _7YA_HVOYA.Context.Contracts.Models;

namespace _7YA_HVOYA.Repositories.Contracts
{
    /// <summary>
    /// Репозиторий чтения <see cref="Storage"/>
    /// </summary>
    public interface IStorageReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Storage"/>
        /// </summary>
        Task<IReadOnlyCollection<Storage>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Storage"/> по идентификатору
        /// </summary>
        Task<Storage?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Storage"/> по идентификаторам
        /// </summary>
        Task<Dictionary<Guid, Storage>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);


    }
}
