using _7YA_HVOYA.Common.Entity.InterfaceDB;
using _7YA_HVOYA.Context.Contracts.Models;
using _7YA_HVOYA.Repositories.Contracts;
using _7YA_HVOYA.Services.Contracts.Exceptions;
using _7YA_HVOYA.Services.Contracts.Interface;
using _7YA_HVOYA.Services.Contracts.Models;
using AutoMapper;

namespace _7YA_HVOYA.Services.Implementations
{
    public class OrderService : IOrderService, IServiceAnchor
    {
        private readonly IOrderReadRepository orderReadRepository;
        private readonly IOrderWriteRepository orderWriteRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public OrderService(IOrderReadRepository orderReadRepository,
            IOrderWriteRepository orderWriteRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.orderReadRepository = orderReadRepository;
            this.orderWriteRepository = orderWriteRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;

        }

        async Task<OrderModel> IOrderService.AddAsync(OrderModel orderModel, CancellationToken cancellationToken)
        {
            var item = new Order
            {
                Id = Guid.NewGuid(),
                ClientId = orderModel.Client.Id,
                ThingId = orderModel.Thing.Id,
                Amount = orderModel.Amount,
            };

            orderWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<OrderModel>(item);
        }

        async Task IOrderService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetStorage = await orderReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetStorage == null)
            {
                throw new FamilyHvoyaEntityNotFoundException<Order>(id);
            }

            if (targetStorage.DeletedAt.HasValue)
            {
                throw new FamilyHvoyaInvalidOperationException($"Размещение с идентификатором {id} уже удалено");
            }

            orderWriteRepository.Delete(targetStorage);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        async Task<OrderModel> IOrderService.EditAsync(OrderModel source, CancellationToken cancellationToken)
        {
            var targetStorage = await orderReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetStorage == null)
            {
                throw new FamilyHvoyaEntityNotFoundException<Order>(source.Id);
            }

            targetStorage.ClientId = source.Client.Id;
            targetStorage.ThingId = source.Thing.Id;
            targetStorage.Amount = source.Amount;
            orderWriteRepository.Update(targetStorage);

            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<OrderModel>(targetStorage);
        }

        async Task<IEnumerable<OrderModel>> IOrderService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await orderReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<OrderModel>>(result);
        }

        async Task<OrderModel?> IOrderService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await orderReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new FamilyHvoyaEntityNotFoundException<Order>(id);
            }
            return mapper.Map<OrderModel>(item);
        }
    }
}
