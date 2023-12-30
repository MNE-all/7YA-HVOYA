using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Services.Contracts.Models
{
    /// <summary>
    /// Модель склада
    /// </summary>
    public class StorageModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Адресс
        /// </summary>
        public string Address { get; set; } = string.Empty;
    }
}
