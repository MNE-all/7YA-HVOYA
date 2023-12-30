using _7YA_HVOYA.Services.Contracts.Emuns;

namespace _7YA_HVOYA.Services.Contracts.Models
{
    /// <summary>
    /// Модель вещи
    /// </summary>
    public class ThingModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <inheritdoc cref="Categories"/>
        public CategoriesModel Category { get; set; } = CategoriesModel.Hats;

        /// <inheritdoc cref="Genders"/>
        public GendersModel? Gender { get; set; }

        /// <inheritdoc cref="Seasons"/>
        public SeasonsModel Season { get; set; } = SeasonsModel.Demi_season;

        /// <inheritdoc cref="Sizes"/>
        public SizesModel Size { get; set; } = SizesModel.M;

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
