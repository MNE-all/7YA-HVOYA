using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Services.Contracts.Models
{
    public class OrderModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Номер заказа
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Вещь
        /// </summary>
        public ThingModel Thing { get; set; }
        /// <summary>
        /// Cвязь один ко многим
        /// </summary>
        public Guid? ThingId { get; set; }
        /// <summary>

        /// <summary>
        /// Количество
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// Клиент (кто заказал)
        /// </summary>
        public ClientModel Client { get; set; }
        /// <summary>
        /// Cвязь один ко многим
        /// </summary>
        public Guid? ClientId { get; set; }
    }
}
