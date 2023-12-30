using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Services.Contracts.Exceptions
{
    /// <summary>
    /// Базовый класс исключений
    /// </summary>
    public abstract class FamilyHvoyaException : Exception
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="FamilyHvoyaException"/> без параметров
        /// </summary>
        protected FamilyHvoyaException() { }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="FamilyHvoyaException"/> с указанием
        /// сообщения об ошибке
        /// </summary>
        protected FamilyHvoyaException(string message)
            : base(message) { }
    }
}
