using _7YA_HVOYA.Context.Contracts.Emuns;

namespace _7YA_HVOYA.API.Models
{
    /// <summary>
    /// Модель ответа сущности размещения
    /// </summary>
    public class AccommodationResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование склада
        /// </summary>
        public string? NameStorage { get; set; }

        /// <summary>
        /// Наименование вещи
        /// </summary>
        public string? NameThing { get; set; }
        /// <summary>
        /// Размер вещи
        /// </summary>
        public Sizes? Size { get; set; } = Sizes.M;

        /// <summary>
        /// Количество
        /// </summary>
        public short Amount { get; set; }
    }
}
