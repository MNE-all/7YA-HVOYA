using _7YA_HVOYA.API.ModelsRequest.Cart;
using _7YA_HVOYA.Repositories.Contracts;
using FluentValidation;

namespace _7YA_HVOYA.API.Validators.Cart
{
    public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
    {
        public CreateCartRequestValidator(IClientReadRepository clientReadRepository,
            IThingReadRepository thingReadRepository)
        {
            RuleFor(x => x.Amount)
             .NotNull()
             .NotEmpty()
             .WithMessage("Количество не должно быть пустым или null");

            RuleFor(x => x.Thing)
                .NotNull()
                .NotEmpty()
                .WithMessage("Вещь не должна быть пустым или null")
                .MustAsync(async (id, CancellationToken) =>
                {
                    var thing = await thingReadRepository.GetByIdAsync(id, CancellationToken);
                    return thing != null;
                })
                .WithMessage("Такой вещи не существует!");

            RuleFor(x => x.Client)
                .NotNull()
                .NotEmpty()
                .WithMessage("Клиент не должен быть пустым или null")
                .MustAsync(async (id, CancellationToken) =>
                {
                    var client = await clientReadRepository.GetByIdAsync(id, CancellationToken);
                    return client != null;
                })
                .WithMessage("Такого клиента не существует!");
        }
    }
}
