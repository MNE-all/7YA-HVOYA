using _7YA_HVOYA.Services.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Services.Contracts.Interface
{
    /// <summary>
    /// Сервис для работы со информацией о складах
    /// </summary>
    public interface IStorageService
    {
        /// <summary>
        /// Получить список всех <see cref="StorageModel"/>
        /// </summary>
        Task<IEnumerable<StorageModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="StorageModel"/> по идентификатору
        /// </summary>
        Task<StorageModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новый склад
        /// </summary>
        Task<StorageModel> AddAsync(string name, string address, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующуий склад
        /// </summary>
        Task<StorageModel> EditAsync(StorageModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующуий склад
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

    }
}
