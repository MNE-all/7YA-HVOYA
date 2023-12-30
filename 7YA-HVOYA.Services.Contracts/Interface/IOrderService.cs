using _7YA_HVOYA.Services.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Services.Contracts.Interface
{
    public interface IOrderService
    {
        /// <summary>
        /// Получить список всех <see cref="OrderModel"/>
        /// </summary>
        Task<IEnumerable<OrderModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="OrderModel"/> по идентификатору
        /// </summary>
        Task<OrderModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новый заказ
        /// </summary>
        Task<OrderModel> AddAsync(OrderModel orderModel, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующий заказ
        /// </summary>
        Task<OrderModel> EditAsync(OrderModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующий заказ
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
