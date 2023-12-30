using _7YA_HVOYA.API.ModelsRequest.Order;
using _7YA_HVOYA.API.ModelsRequest.Storage;
using _7YA_HVOYA.Repositories.Contracts;

using FluentValidation;

namespace _7YA_HVOYA.API.Validators.Order
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        /// <summary>
        /// Инициализирую <see cref="CreateOrderRequestValidator"/>
        /// </summary>
        public CreateOrderRequestValidator(IClientReadRepository clientReadRepository)
        {
            RuleFor(order => order.ClientId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Имя не должно быть пустым или null")
                .MustAsync(async (id, CancellationToken) =>
                {
                    var client = await clientReadRepository.GetByIdAsync(id, CancellationToken);
                    return client != null;
                })
                .WithMessage("Такого пользоваетля не существует!");

            RuleFor(order => order.ThingId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Имя не должно быть пустым или null");

            RuleFor(order => order.Amount)
                .NotNull()
                .NotEmpty()
                .WithMessage("Имя не должно быть пустым или null");

            RuleFor(order => order.Number)
                .NotNull()
                .NotEmpty()
                .WithMessage("Имя не должно быть пустым или null");
        }
    }
}
