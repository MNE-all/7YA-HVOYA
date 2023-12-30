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
    public abstract class FamilyHvoyaNotFoundException : FamilyHvoyaException
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="FamilyHvoyaNotFoundException"/> с указанием
        /// сообщения об ошибке
        /// </summary>
        public FamilyHvoyaNotFoundException(string message)
            : base(message)
        { }
    }
}
