using _7YA_HVOYA.Common.Entity.InterfaceDB;
using _7YA_HVOYA.Context.Contracts.Models;
using _7YA_HVOYA.Repositories.Contracts;
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
        async Task<ThingModel> AddAsync(ThingModel thing, CancellationToken cancellationToken)
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

        Task<ThingModel> IThingService.AddAsync(ThingModel timeTable, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IThingService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ThingModel> IThingService.EditAsync(ThingModel source, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ThingModel>> IThingService.GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ThingModel?> IThingService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
