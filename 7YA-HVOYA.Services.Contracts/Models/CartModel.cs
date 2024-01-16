using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Services.Contracts.Models
{
    public class CartModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Вещь
        /// </summary>
        public ThingModel Thing { get; set; }
        /// <summary>
        /// Клиент
        /// </summary>
        public ClientModel Client { get; set; }
        
        /// <summary>
        /// Количество
        /// </summary>
        public int Amount { get; set; }
    }
}
