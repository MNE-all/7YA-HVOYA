using _7YA_HVOYA.API.ModelsRequest.Thing;
using FluentValidation;

namespace _7YA_HVOYA.API.Validators.Thing
{
    public class ThingRequestValidator : AbstractValidator<ThingRequest>
    {
        public ThingRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Название не должно быть пустым или null");

            RuleFor(x => x.Size)
                .NotNull()
                .NotEmpty()
                .WithMessage("Размер не должен быть пустым или null");

            RuleFor(x => x.Price)
                .NotNull()
                .NotEmpty()
                .WithMessage("Цена не должна быть пустой или null");

            RuleFor(x => x.Season)
                .NotNull()
                .NotEmpty()
                .WithMessage("Сезон не должен быть пустой или null");

            RuleFor(x => x.Gender)
                .NotNull()
                .NotEmpty()
                .WithMessage("Пол не должен быть пустой или null");

            RuleFor(x => x.Category)
                .NotNull()
                .NotEmpty()
                .WithMessage("Категория не должна быть пустой или null");
        }
    }
}
