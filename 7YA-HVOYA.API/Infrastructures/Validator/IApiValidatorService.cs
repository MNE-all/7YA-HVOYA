namespace _7YA_HVOYA.API.Infrastructures.Validator
{
    /// <summary>
    /// Сервис валидации
    /// </summary>
    public interface IApiValidatorService
    {
        /// <summary>
        /// Валидирует модель
        /// </summary>
        Task ValidateAsync<TModel>(TModel model, CancellationToken cancellationToken)
            where TModel : class;
    }
}
