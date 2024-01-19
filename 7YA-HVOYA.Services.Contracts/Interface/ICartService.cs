using _7YA_HVOYA.Services.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Services.Contracts.Interface
{
    public interface ICartService
    {
        /// <summary>
        /// Получить список всех <see cref="CartModel"/>
        /// </summary>
        Task<IEnumerable<CartModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="TimeTableItemModel"/> по идентификатору
        /// </summary>
        Task<CartModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет товар в корзину
        /// </summary>
        Task<CartModel> AddAsync(CartModel cartModel, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует товар в корзине
        /// </summary>
        Task<CartModel> EditAsync(CartModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующий товар в корзине
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
