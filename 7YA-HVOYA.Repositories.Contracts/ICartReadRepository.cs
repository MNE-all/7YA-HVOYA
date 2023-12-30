using _7YA_HVOYA.Context.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Repositories.Contracts
{
    public interface ICartReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Cart"/>
        /// </summary>
        Task<IReadOnlyCollection<Cart>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Cart"/> по идентификатору
        /// </summary>
        Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        /// <summary>
        /// Получить список <see cref="Cart"/> по идентификатору пользователя
        /// </summary>
        Task<IReadOnlyCollection<Cart>> GetByClientIdAsync(Guid clientId, CancellationToken cancellation);

    }
}
