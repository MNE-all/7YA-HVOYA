namespace _7YA_HVOYA.API.ModelsRequest.Storage
{
    /// <summary>
    /// Модель запроса создания склада
    /// </summary>
    public class CreateStorageRequest
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; } = string.Empty;
    }
}
