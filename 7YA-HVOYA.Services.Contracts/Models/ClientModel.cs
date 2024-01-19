using _7YA_HVOYA.Services.Contracts.Emuns;

namespace _7YA_HVOYA.Services.Contracts.Models
{
    /// <summary>
    /// Модель клиента
    /// </summary>
    public class ClientModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string? Surname { get; set; } = string.Empty;
        /// <summary>
        /// Имя
        /// </summary>
        public string? Name { get; set; } = string.Empty;
        /// <summary>
        /// Отчество
        /// </summary>
        public string? Patronymic { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        public GendersModel Gender { get; set; } = GendersModel.Male;
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTimeOffset? Birthday { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string Phone { get; set; } = string.Empty;
        /// <summary>
        /// Электронная почта
        /// </summary>
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
