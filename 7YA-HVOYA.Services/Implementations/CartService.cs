using _7YA_HVOYA.Common.Entity.InterfaceDB;
using _7YA_HVOYA.Context.Contracts.Models;
using _7YA_HVOYA.Repositories.Contracts;
using _7YA_HVOYA.Services.Contracts.Exceptions;
using _7YA_HVOYA.Services.Contracts.Interface;
using _7YA_HVOYA.Services.Contracts.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Services.Implementations
{
    public class CartService : ICartService, IServiceAnchor
    {
        private readonly ICartReadRepository cartReadRepository;
        private readonly ICartWriteRepository cartWriteRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CartService(ICartReadRepository cartReadRepository,
        ICartWriteRepository cartWriteRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
        {
            this.cartReadRepository = cartReadRepository;
            this.cartWriteRepository = cartWriteRepository; 
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        async Task<CartModel> ICartService.AddAsync(CartModel cartModel, CancellationToken cancellationToken)
        {
            var item = new Cart
            {
                Id = Guid.NewGuid(),
                ClientId = cartModel.Client.Id,
                ThingId = cartModel.Thing.Id,
                Amount = cartModel.Amount,
            };

            cartWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<CartModel>(item);
        }

        async Task ICartService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetStorage = await cartReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetStorage == null)
            {
                throw new FamilyHvoyaEntityNotFoundException<Cart>(id);
            }

            if (targetStorage.DeletedAt.HasValue)
            {
                throw new FamilyHvoyaInvalidOperationException($"Элемент корзины с идентификатором {id} уже удалено");
            }

            cartWriteRepository.Delete(targetStorage);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        async Task<CartModel> ICartService.EditAsync(CartModel source, CancellationToken cancellationToken)
        {
            var targetStorage = await cartReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetStorage == null)
            {
                throw new FamilyHvoyaEntityNotFoundException<Cart>(source.Id);
            }

            targetStorage.ClientId = source.Client.Id;
            targetStorage.ThingId = source.Thing.Id;
            targetStorage.Amount = source.Amount;
            cartWriteRepository.Update(targetStorage);

            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<CartModel>(targetStorage);
        }

        async Task<IEnumerable<CartModel>> ICartService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await cartReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<CartModel>>(result);
        }

        async Task<CartModel?> ICartService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await cartReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new FamilyHvoyaEntityNotFoundException<Cart>(id);
            }
            return mapper.Map<CartModel>(item);
        }
    }
}
