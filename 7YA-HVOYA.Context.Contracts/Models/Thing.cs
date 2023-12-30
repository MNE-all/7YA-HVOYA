using _7YA_HVOYA.Context.Contracts.Emuns;

namespace _7YA_HVOYA.Context.Contracts.Models
{
    /// <summary>
    /// Вещь (одежда)
    /// </summary>
    public class Thing : BaseAuditEntity
    {
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

        /// <summary>
        /// нужна для связи один ко многим по вторичному ключу <see cref="Cart"/>
        /// </summary>
        public ICollection<Cart>? Cart { get; set; }

        /// <summary>
        /// нужна для связи один ко многим по вторичному ключу <see cref="Order"/>
        /// </summary>
        public ICollection<Order>? Order { get; set; }
        /// <summary>
        /// нужна для связи один ко многим по вторичному ключу <see cref="Accommodation"/> 
        /// </summary>
        public ICollection<Accommodation>? Accommodation { get; set; }
    }
}
