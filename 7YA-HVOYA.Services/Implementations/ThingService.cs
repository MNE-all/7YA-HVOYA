using _7YA_HVOYA.Common.Entity.InterfaceDB;
using _7YA_HVOYA.Context.Contracts.Emuns;
using _7YA_HVOYA.Context.Contracts.Models;
using _7YA_HVOYA.Repositories.Contracts;
using _7YA_HVOYA.Services.Contracts.Exceptions;
using _7YA_HVOYA.Services.Contracts.Interface;
using _7YA_HVOYA.Services.Contracts.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Services.Implementations
{
    public class ThingService : IThingService, IServiceAnchor
    {
        private readonly IThingReadRepository thingReadRepository;
        private readonly IThingWriteRepository thingWriteRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;


        public ThingService(IThingReadRepository thingReadRepository,
            IThingWriteRepository thingWriteRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.thingReadRepository = thingReadRepository;
            this.thingWriteRepository = thingWriteRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        async Task<ThingModel> IThingService.AddAsync(ThingModel thing, CancellationToken cancellationToken)
        {
            var item = new Thing
            {
                Id = Guid.NewGuid(),
                Name = thing.Name,
                Category = thing.Category,
                Season = thing.Season,
                Gender = thing.Gender,
                Price = thing.Price,
                ImgURL = thing.ImgURL,
            };
            thingWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<ThingModel>(item);
        }

        async Task IThingService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetThing = await thingReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetThing == null)
            {
                throw new FamilyHvoyaEntityNotFoundException<Thing>(id);
            }

            if (targetThing.DeletedAt.HasValue)
            {
                throw new FamilyHvoyaInvalidOperationException($"Вещь с идентификатором {id} уже удалена");
            }

            thingWriteRepository.Delete(targetThing);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        async Task<ThingModel> IThingService.EditAsync(ThingModel source, CancellationToken cancellationToken)
        {
            var targetThing = await thingReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetThing == null)
            {
                throw new FamilyHvoyaEntityNotFoundException<Thing>(source.Id);
            }

            targetThing.Name = source.Name;
            targetThing.Category = source.Category;
            targetThing.Season = source.Season;
            targetThing.Gender = source.Gender;
            targetThing.Price = source.Price;
            targetThing.ImgURL = source.ImgURL;
            thingWriteRepository.Update(targetThing);

            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<ThingModel>(targetThing);
        }

        async Task<IEnumerable<ThingModel>> IThingService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await thingReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<ThingModel>>(result);
        }

        async Task<ThingModel?> IThingService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await thingReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new FamilyHvoyaEntityNotFoundException<Thing>(id);
            }
            return mapper.Map<ThingModel>(item);
        }
    }
}
