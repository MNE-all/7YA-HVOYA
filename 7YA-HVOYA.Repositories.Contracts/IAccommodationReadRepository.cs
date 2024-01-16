using _7YA_HVOYA.Context.Contracts.Models;

namespace _7YA_HVOYA.Repositories.Contracts
{
    /// <summary>
    /// Репозиторий чтения <see cref="Accommodation"/>
    /// </summary>
    public interface IAccommodationReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Accommodation"/> 
        /// </summary>
        Task<IReadOnlyCollection<Accommodation>> GetAllAsync(CancellationToken cancellationToken);
        /// <summary>
        /// Получить список всех <see cref="Accommodation"/> находящихся на складе <see langword="storageName"/> 
        /// </summary>
        Task<IReadOnlyCollection<Accommodation>> GetAllByStorageNameAsync(string storageName, CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Accommodation"/> по идентификатору
        /// </summary>
        Task<Accommodation?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
