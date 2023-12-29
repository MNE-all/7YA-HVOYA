namespace _7YA_HVOYA.Context.Contracts.Models
{
    /// <summary>
    /// Размещение на складе
    /// </summary>
    public class Accommodation : BaseAuditEntity
    {
        /// <summary>
        /// Вещь
        /// </summary>
        public Thing Thing { get; set; }
        /// <summary>
        /// Cвязь один ко многим
        /// </summary>
        public Guid? ThingId { get; set; }

        /// <summary>
        /// Склад
        /// </summary>
        public Storage Storage { get; set; }
        /// <summary>
        /// Cвязь один ко многим
        /// </summary>
        public Guid? StorageId { get; set; }

        /// <summary>
        /// <summary>
        /// Количество в наличии
        /// </summary>
        public int Amount { get; set; }
    }
}
