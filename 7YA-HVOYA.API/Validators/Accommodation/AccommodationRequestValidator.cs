using _7YA_HVOYA.API.ModelsRequest.Accommodation;
using _7YA_HVOYA.Repositories.Contracts;
using _7YA_HVOYA.Repositories.Implementations;
using FluentValidation;

namespace _7YA_HVOYA.API.Validators.Accommodation
{
    public class AccommodationRequestValidator : AbstractValidator<AccommodationRequest>
    {
        public AccommodationRequestValidator(IStorageReadRepository storageReadRepository,
            IThingReadRepository thingReadRepository)
        {
            RuleFor(x => x.Amount)
                .NotNull()
                .NotEmpty()
                .WithMessage("Количество не должен быть пустым или null");

            RuleFor(x => x.Storage)
                .NotNull()
                .NotEmpty()
                .WithMessage("Склад не должен быть пустым или null")
                .MustAsync(async (id, CancellationToken) =>
                {
                    var storage = await storageReadRepository.GetByIdAsync(id, CancellationToken);
                    return storage != null;
                })
                .WithMessage("Такого склада не существует!");
        }
    }
}
