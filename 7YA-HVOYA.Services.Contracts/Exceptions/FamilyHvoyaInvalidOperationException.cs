using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Services.Contracts.Exceptions
{
    /// <summary>
    /// Ошибка выполнения операции
    /// </summary>
    public class FamilyHvoyaInvalidOperationException : FamilyHvoyaException
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="FamilyHvoyaInvalidOperationException"/>
        /// с указанием сообщения об ошибке
        /// </summary>
        public FamilyHvoyaInvalidOperationException(string message)
            : base(message)
        {

        }
    }
}
