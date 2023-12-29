using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Context.Contracts.Models
{
    /// <summary>
    /// Корзина пользователей
    /// </summary>
    public class Cart : BaseAuditEntity
    {
        /// <summary>
        /// Вещь
        /// </summary>
        public Thing Thing { get; set; }
        /// <summary>
        /// Cвязь один ко многим
        /// </summary>
        public Guid? ThingId { get; set; }
        /// <summary>
        /// Клиент
        /// </summary>
        public Client Client { get; set; }
        /// <summary>
        /// Cвязь один ко многим
        /// </summary>
        public Guid? ClientId { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public int Amount { get; set; }
    }
}
