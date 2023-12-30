using _7YA_HVOYA.Services.Contracts.Models;
using _7YA_HVOYA.Services.Contracts.ModelsRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Services.Contracts.Interface
{
    public interface IClientService
    {
        /// <summary>
        /// Получить список всех <see cref="ClientModel"/>
        /// </summary>
        Task<IEnumerable<ClientModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="ClientModel"/> по идентификатору
        /// </summary>
        Task<ClientModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет нового клиента
        /// </summary>
        Task<ClientModel> AddAsync(ClientRequestModel clientRequestModel, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует клиента
        /// </summary>
        Task<ClientModel> EditAsync(ClientRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующего клиента
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
