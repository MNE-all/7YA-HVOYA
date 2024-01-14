using _7YA_HVOYA.Common.Entity.InterfaceDB;
using _7YA_HVOYA.Context.Contracts.Models;
using _7YA_HVOYA.Repositories.Contracts;
using _7YA_HVOYA.Services.Contracts.Exceptions;
using _7YA_HVOYA.Services.Contracts.Interface;
using _7YA_HVOYA.Services.Contracts.Models;
using AutoMapper;

namespace _7YA_HVOYA.Services.Implementations
{
    /// <inheritdoc cref="IStorageService"/>
    public class StorageService : IStorageService, IServiceAnchor
    {
        private readonly IStorageReadRepository storageReadRepository;
        private readonly IStorageWriteRepository storageWriteRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public StorageService(IStorageReadRepository storageReadRepository, IStorageWriteRepository storageWriteRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.storageReadRepository = storageReadRepository;
            this.storageWriteRepository = storageWriteRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        async Task<StorageModel> IStorageService.AddAsync(string name, string address, CancellationToken cancellationToken)
        {
            var item = new Storage
            {
                Id = Guid.NewGuid(),
                Name = name,
                Address = address,
            };
            
            storageWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<StorageModel>(item);
        }

        async Task IStorageService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetStorage = await storageReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetStorage == null)
            {
                throw new FamilyHvoyaEntityNotFoundException<Storage>(id);
            }

            if (targetStorage.DeletedAt.HasValue)
            {
                throw new FamilyHvoyaInvalidOperationException($"Склад с идентификатором {id} уже удален");
            }

            storageWriteRepository.Delete(targetStorage);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        async Task<StorageModel> IStorageService.EditAsync(StorageModel source, CancellationToken cancellationToken)
        {
            var targetStorage = await storageReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetStorage == null)
            {
                throw new FamilyHvoyaEntityNotFoundException<Storage>(source.Id);
            }

            targetStorage.Name = source.Name;
            targetStorage.Address = source.Address;
            storageWriteRepository.Update(targetStorage);

            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<StorageModel>(targetStorage);
        }

        async Task<StorageModel> IStorageService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await storageReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new FamilyHvoyaEntityNotFoundException<Storage>(id);
            }
            return mapper.Map<StorageModel>(item);
        }

        async Task<IEnumerable<StorageModel>> IStorageService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await storageReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<StorageModel>>(result);
        }
    }
}
