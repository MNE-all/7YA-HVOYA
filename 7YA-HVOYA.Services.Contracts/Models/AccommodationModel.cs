using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Services.Contracts.Models
{
    public class AccommodationModel
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Вещь
        /// </summary>
        public ThingModel Thing { get; set; }

        /// <summary>
        /// Склад
        /// </summary>
        public StorageModel Storage { get; set; }

        /// <summary>
        /// <summary>
        /// Количество в наличии
        /// </summary>
        public int Amount { get; set; }
    }
}
