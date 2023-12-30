using _7YA_HVOYA.Context.Contracts.Emuns;

namespace _7YA_HVOYA.API.Models
{
    /// <summary>
    /// Модель ответа сущности вещи
    /// </summary>
    public class ThingResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название вещи
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <inheritdoc cref="Categories"/>
        public Categories Category { get; set; } = Categories.Hats;

        /// <inheritdoc cref="Genders"/>
        public Genders? Gender { get; set; }

        /// <inheritdoc cref="Seasons"/>
        public Seasons Season { get; set; } = Seasons.Demi_season;

        /// <inheritdoc cref="Sizes"/>
        public Sizes Size { get; set; } = Sizes.M;

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Адрес изображения или альбома
        /// </summary>
        public string ImgURL { get; set; } = string.Empty;
    }
}
