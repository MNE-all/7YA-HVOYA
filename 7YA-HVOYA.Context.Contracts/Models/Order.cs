using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Context.Contracts.Models
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order : BaseAuditEntity
    {
        /// <summary>
        /// Номер заказа
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Вещь
        /// </summary>
        public Thing Thing { get; set; }
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
        public Client Client { get; set; }
        /// <summary>
        /// Cвязь один ко многим
        /// </summary>
        public Guid? ClientId { get; set; }
    }
}
