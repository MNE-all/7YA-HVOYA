using FluentValidation;
using _7YA_HVOYA.API.ModelsRequest.Storage;


namespace _7YA_HVOYA.API.Validators.Storage
{
    /// <summary>
    /// Валидатор класса <see cref="CreateStorageRequest"/>
    /// </summary>
    public class CreateStorageRequestValidator : AbstractValidator<CreateStorageRequest>
    {
        /// <summary>
        /// Инициализирую <see cref="CreateStorageRequestValidator"/>
        /// </summary>
        public CreateStorageRequestValidator()
        {
            RuleFor(discipline => discipline.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Имя не должно быть пустым или null");
        }
    }
}
