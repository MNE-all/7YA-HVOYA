namespace _7YA_HVOYA.API.Models
{
    /// <summary>
    /// Модель ответа сущности склада
    /// </summary>
    public class StorageResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Описание
        /// </summary>
        public string Address { get; set; } = string.Empty;
    }
}
