﻿using _7YA_HVOYA.Context.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Repositories.Contracts
{
    public interface IOrderReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Order"/>
        /// </summary>
        Task<IReadOnlyCollection<Order>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Order"/> по идентификатору
        /// </summary>
        Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        /// <summary>
        /// Получить список <see cref="Order"/> по номеру заказа
        /// </summary>
        Task<IReadOnlyCollection<Order>> GetByIdsAsync(int number, CancellationToken cancellation);

    }
}
