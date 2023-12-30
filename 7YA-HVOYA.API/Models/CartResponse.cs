using _7YA_HVOYA.Context.Contracts.Emuns;

namespace _7YA_HVOYA.API.Models
{
    /// <summary>
    /// Модель ответа сущность корзина
    /// </summary>
    public class CartResponse
    {

        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование вещи
        /// </summary>
        public string? NameThing { get; set; }
        /// <summary>
        /// Размер вещи
        /// </summary>
        public Sizes? Size { get; set; } = Sizes.M;

        /// <summary>
        /// Электронная почта пользователя
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Количество
        /// </summary>
        public int Amount { get; set; }
    }
}
