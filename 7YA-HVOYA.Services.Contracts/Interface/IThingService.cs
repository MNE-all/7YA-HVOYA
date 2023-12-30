using _7YA_HVOYA.Services.Contracts.Models;

namespace _7YA_HVOYA.Services.Contracts.Interface
{
    public interface IThingService
    {
        /// <summary>
        /// Получить список всех <see cref="ThingModel"/>
        /// </summary>
        Task<IEnumerable<ThingModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="ThingModel"/> по идентификатору
        /// </summary>
        Task<ThingModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет вещь
        /// </summary>
        Task<ThingModel> AddAsync(ThingModel timeTable, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует вещь
        /// </summary>
        Task<ThingModel> EditAsync(ThingModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующую вещь
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
