using System.Text.RegularExpressions;
using _7YA_HVOYA.Context.Contracts.Models;


namespace _7YA_HVOYA.Repositories.Contracts
{
    public interface IClientReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Client"/>
        /// </summary>
        Task<IReadOnlyCollection<Client>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Client"/> по идентификатору
        /// </summary>
        Task<Client?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
