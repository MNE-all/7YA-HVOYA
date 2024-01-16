using _7YA_HVOYA.Services.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Services.Contracts.Interface
{
    public interface IAccommodationService
    {
        /// <summary>
        /// Получить список всех <see cref="AccommodationModel"/>
        /// </summary>
        Task<IEnumerable<AccommodationModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="AccommodationModel"/> по идентификатору
        /// </summary>
        Task<AccommodationModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новое размещение
        /// </summary>
        Task<AccommodationModel> AddAsync(AccommodationModel accommodation, CancellationToken cancellationToken);

        /// <summary>
        /// Изменяет размещение
        /// </summary>
        Task<AccommodationModel> EditAsync(AccommodationModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующее размещение
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
