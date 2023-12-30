using System.ComponentModel;
namespace _7YA_HVOYA.API.Models.Enums
{
    /// <summary>
    /// Виды сезонов
    /// </summary>
    public enum SeasonsResponse
    {
        /// <summary>
        /// Демисезоная
        /// </summary>
        [Description("Демисезоная")]
        Demi_season,

        /// <summary>
        /// Лето
        /// </summary>
        [Description("Лето")]
        Summer,

        /// <summary>
        /// Осень
        /// </summary>
        [Description("Осень")]
        Autumn,

        /// <summary>
        /// Зима
        /// </summary>
        [Description("Зима")]
        Winter,

        /// <summary>
        /// Весна
        /// </summary>
        [Description("Весна")]
        Spring,
    }

}
