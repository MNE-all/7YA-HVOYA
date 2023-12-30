using _7YA_HVOYA.Shared;
namespace _7YA_HVOYA.Services.Contracts.Exceptions
{
    /// <summary>
    /// Ошибки валидации
    /// </summary>
    public class FamilyHvoyaValidationException : FamilyHvoyaException
    {
        /// <summary>
        /// Ошибки
        /// </summary>
        public IEnumerable<InvalidateItemModel> Errors { get; }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="AdministrationValidationException"/>
        /// </summary>
        public FamilyHvoyaValidationException(IEnumerable<InvalidateItemModel> errors)
        {
            Errors = errors;
        }
    }
}
