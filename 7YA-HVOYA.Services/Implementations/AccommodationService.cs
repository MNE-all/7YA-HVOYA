using _7YA_HVOYA.Common.Entity.InterfaceDB;
using _7YA_HVOYA.Context.Contracts.Models;
using _7YA_HVOYA.Repositories.Contracts;
using _7YA_HVOYA.Services.Contracts.Exceptions;
using _7YA_HVOYA.Services.Contracts.Interface;
using _7YA_HVOYA.Services.Contracts.Models;
using AutoMapper;
using System.Net;
using System.Xml.Linq;

namespace _7YA_HVOYA.Services.Implementations
{
    public class AccommodationService : IAccommodationService, IServiceAnchor
    {
        private readonly IAccommodationReadRepository accommodationReadRepository;
        private readonly IAccommodationWriteRepository accommodationWriteRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AccommodationService(IAccommodationReadRepository accommodationReadRepository, IAccommodationWriteRepository accommodationWriteRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.accommodationReadRepository = accommodationReadRepository;
            this.accommodationWriteRepository = accommodationWriteRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        async Task<AccommodationModel> IAccommodationService.AddAsync(AccommodationModel accommodation, CancellationToken cancellationToken)
        {
            var item = new Accommodation
            {
                Id = Guid.NewGuid(),
                StorageId = accommodation.Storage.Id,
                ThingId = accommodation.Thing.Id,
                Amount = accommodation.Amount,
            };

            accommodationWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<AccommodationModel>(item);
        }

        async Task IAccommodationService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetStorage = await accommodationReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetStorage == null)
            {
                throw new FamilyHvoyaEntityNotFoundException<Accommodation>(id);
            }

            if (targetStorage.DeletedAt.HasValue)
            {
                throw new FamilyHvoyaInvalidOperationException($"Размещение с идентификатором {id} уже удалено");
            }

            accommodationWriteRepository.Delete(targetStorage);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        async Task<IEnumerable<AccommodationModel>> IAccommodationService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await accommodationReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<AccommodationModel>>(result);
        }

        async Task<AccommodationModel?> IAccommodationService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await accommodationReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new FamilyHvoyaEntityNotFoundException<Accommodation>(id);
            }
            return mapper.Map<AccommodationModel>(item);
        }

        async Task<AccommodationModel> IAccommodationService.EditAsync(AccommodationModel source, CancellationToken cancellationToken)
        {
            var targetStorage = await accommodationReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetStorage == null)
            {
                throw new FamilyHvoyaEntityNotFoundException<Accommodation>(source.Id);
            }

            targetStorage.ThingId = source.Thing.Id;
            targetStorage.StorageId = source.Storage.Id;
            targetStorage.Amount = source.Amount;
            accommodationWriteRepository.Update(targetStorage);

            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<AccommodationModel>(targetStorage);
        }
    }
}
