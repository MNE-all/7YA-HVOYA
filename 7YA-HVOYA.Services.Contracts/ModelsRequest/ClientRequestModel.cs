using _7YA_HVOYA.Context.Contracts.Emuns;
using _7YA_HVOYA.Services.Contracts.Emuns;

namespace _7YA_HVOYA.Services.Contracts.ModelsRequest
{
    public class ClientRequestModel
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
        public Genders Gender { get; set; } = Genders.Male;
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateOnly? Birthday { get; set; }
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