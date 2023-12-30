using _7YA_HVOYA.API.ModelsRequest.Storage;
using FluentValidation;

namespace _7YA_HVOYA.API.Validators.Storage
{
    public class StorageRequestValidator : AbstractValidator<StorageRequest>
    {
        public StorageRequestValidator()
        {
            RuleFor(storage => storage.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Название не должно быть пустым или null");

            RuleFor(storage => storage.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("Id не должно быть пустым или null");
        }
    }
}
