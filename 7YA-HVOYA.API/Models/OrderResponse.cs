using _7YA_HVOYA.Context.Contracts.Emuns;

namespace _7YA_HVOYA.API.Models
{
    /// <summary>
    /// Модель ответа сущности вещи
    /// </summary>
    public class OrderResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Номер заказа
        /// </summary>
        public int Number { get; set; }

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
        public int Amount { get; set; }


        /// <summary>
        /// Электронная почта
        /// </summary>
        public string Email { get; set; } = string.Empty;
    }
}
