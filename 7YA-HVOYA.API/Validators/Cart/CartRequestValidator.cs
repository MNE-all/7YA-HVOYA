using FluentValidation;
using _7YA_HVOYA.API.ModelsRequest.Cart;
using _7YA_HVOYA.Repositories.Contracts;

namespace _7YA_HVOYA.API.Validators.Cart
{
    public class CartRequestValidator : AbstractValidator<CartRequest>
    {
        public CartRequestValidator(IClientReadRepository clientReadRepository,
            IThingReadRepository thingReadRepository) 
        {
            RuleFor(x => x.Id)
             .NotNull()
             .NotEmpty()
             .WithMessage("Id не должен быть пустым или null");

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
