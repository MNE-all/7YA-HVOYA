using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Context.Contracts.Models
{
    /// <summary>
    /// Склад
    /// </summary>
    public class Storage : BaseAuditEntity
    {
        /// <summary>
        /// Название склада
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// <summary>
        /// Адрес склада/магазина
        /// </summary>
        public string Address { get; set; } = String.Empty;

        /// <summary>
        /// нужна для связи один ко многим по вторичному ключу <see cref="Accommodation"/>
        /// </summary>
        public ICollection<Accommodation>? Accommodations { get; set; }
    }
}
