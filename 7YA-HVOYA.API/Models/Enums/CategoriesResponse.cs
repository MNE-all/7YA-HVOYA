using System.ComponentModel;

namespace _7YA_HVOYA.API.Models.Enums
{
    /// <summary>
    /// Категории вещей
    /// </summary>
    public enum CategoriesResponse
    {
        /// <summary>
        /// Головные уборы
        /// </summary>
        [Description("Головные уборы")]
        Hats,

        /// <summary>
        /// Куртки
        /// </summary>
        [Description("Куртки")]
        Jackets,

        /// <summary>
        /// Толстовки
        /// </summary>
        [Description("Толстовки")] 
        Sweatshirts,

        /// <summary>
        /// Футболки
        /// </summary>
        [Description("Футболки")] 
        T_shirts,

        /// <summary>
        /// Брюки
        /// </summary>
        [Description("Брюки")] 
        Trousers,

        /// <summary>
        /// Шорты
        /// </summary>
        [Description("Шорты")] 
        Shorts,

        /// <summary>
        /// Носки
        /// </summary>
        [Description("Носки")] 
        Socks,
    }
}
