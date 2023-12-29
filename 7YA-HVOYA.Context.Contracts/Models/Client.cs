using _7YA_HVOYA.Context.Contracts.Emuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Context.Contracts.Models
{
    /// <summary>
    /// Клиент
    /// </summary>
    public class Client : BaseAuditEntity
    {
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

        /// <summary>
        /// нужна для связи один ко многим по вторичному ключу <see cref="Cart"/>
        /// </summary>
        public ICollection<Cart>? Cart { get; set; }
        /// <summary>
        /// нужна для связи один ко многим по вторичному ключу <see cref="Order"/>
        /// </summary>
        public ICollection<Order>? Order { get; set; }
    }
}
