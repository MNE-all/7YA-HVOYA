using FluentValidation;
using _7YA_HVOYA.API.Validators.Accommodation ;
using _7YA_HVOYA.API.Validators.Storage;
using _7YA_HVOYA.API.Validators.Cart;
using _7YA_HVOYA.API.Validators.Client;
using _7YA_HVOYA.API.Validators.Order;
using _7YA_HVOYA.API.Validators.Thing;
using _7YA_HVOYA.Repositories.Contracts;
using _7YA_HVOYA.Services.Contracts.Exceptions;
using _7YA_HVOYA.Shared;

namespace _7YA_HVOYA.API.Infrastructures.Validator
{
    internal sealed class ApiValidatorService : IApiValidatorService
    {
        private readonly Dictionary<Type, IValidator> validators = new Dictionary<Type, IValidator>();

        public ApiValidatorService(IClientReadRepository clientReadRepository,
            IThingReadRepository thingReadRepository,
            IStorageReadRepository storageReadRepository)
        {
            Register<CreateStorageRequestValidator>();
            Register<StorageRequestValidator>();

            Register<CreateClientRequestValidator>();
            Register<ClientRequestValidator>();

            Register<CreateThingRequestValidator>();
            Register<ThingRequestValidator>();


            Register<CreateAccommodationRequestValidator>(storageReadRepository, thingReadRepository);
            Register<AccommodationRequestValidator>(storageReadRepository, thingReadRepository);

            Register<CreateCartRequestValidator>(clientReadRepository, thingReadRepository);
            Register<CartRequestValidator>(clientReadRepository, thingReadRepository);

            Register<CreateOrderRequestValidator>(thingReadRepository, clientReadRepository);
            Register<OrderRequestValidator>(thingReadRepository, clientReadRepository);
        }

        ///<summary>
        /// Регистрирует валидатор в словаре
        /// </summary>
        public void Register<TValidator>(params object[] constructorParams)
            where TValidator : IValidator
        {
            var validatorType = typeof(TValidator);
            var innerType = validatorType.BaseType?.GetGenericArguments()[0];
            if (innerType == null)
            {
                throw new ArgumentNullException($"Указанный валидатор {validatorType} должен быть generic от типа IValidator");
            }

            if (constructorParams?.Any() == true)
            {
                var validatorObject = Activator.CreateInstance(validatorType, constructorParams);
                if (validatorObject is IValidator validator)
                {
                    validators.TryAdd(innerType, validator);
                }
            }
            else
            {
                validators.TryAdd(innerType, Activator.CreateInstance<TValidator>());
            }
        }

        public async Task ValidateAsync<TModel>(TModel model, CancellationToken cancellationToken)
            where TModel : class
        {
            var modelType = model.GetType();
            if (!validators.TryGetValue(modelType, out var validator))
            {
                throw new InvalidOperationException($"Не найден валидатор для модели {modelType}");
            }

            var context = new ValidationContext<TModel>(model);
            var result = await validator.ValidateAsync(context, cancellationToken);

            if (!result.IsValid)
            {
                throw new FamilyHvoyaValidationException(result.Errors.Select(x =>
                InvalidateItemModel.New(x.PropertyName, x.ErrorMessage)));
            }
        }
    }
}
