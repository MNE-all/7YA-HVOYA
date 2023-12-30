using _7YA_HVOYA.API.ModelsRequest.Client;
using FluentValidation;

namespace _7YA_HVOYA.API.Validators.Client
{
    public class ClientRequestValidator : AbstractValidator<ClientRequest>
    {
        public ClientRequestValidator() 
        { 
            RuleFor(x => x.Phone)
                .NotNull()
                .NotEmpty()
                .WithMessage("Название не должно быть пустым или null");

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Размер не должен быть пустым или null");

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Цена не должна быть пустой или null");
        }
    }
}
