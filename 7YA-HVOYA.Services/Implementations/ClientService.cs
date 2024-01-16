using _7YA_HVOYA.Common.Entity.InterfaceDB;
using _7YA_HVOYA.Context.Contracts.Models;
using _7YA_HVOYA.Repositories.Contracts;
using _7YA_HVOYA.Services.Contracts.Exceptions;
using _7YA_HVOYA.Services.Contracts.Interface;
using _7YA_HVOYA.Services.Contracts.Models;
using _7YA_HVOYA.Services.Contracts.ModelsRequest;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Services.Implementations
{
    public class ClientService : IClientService, IServiceAnchor
    {
        private readonly IClientReadRepository clientReadRepository;
        private readonly IClientWriteRepository clientWriteRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ClientService(IClientReadRepository clientReadRepository, IClientWriteRepository clientWriteRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.clientReadRepository = clientReadRepository;
            this.clientWriteRepository = clientWriteRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        async Task<ClientModel> IClientService.AddAsync(ClientRequestModel clientRequestModel, CancellationToken cancellationToken)
        {
            var item = new Client
            {
                Id = Guid.NewGuid(),
                Name = clientRequestModel.Name,
                Surname = clientRequestModel.Surname,
                Patronymic = clientRequestModel.Patronymic,
                Password = clientRequestModel.Password,
                Email = clientRequestModel.Email,
                Phone = clientRequestModel.Phone,
                Gender = clientRequestModel.Gender,
                Birthday = clientRequestModel.Birthday,
            };

            clientWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<ClientModel>(item);
        }

        async Task IClientService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetStorage = await clientReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetStorage == null)
            {
                throw new FamilyHvoyaEntityNotFoundException<Client>(id);
            }

            if (targetStorage.DeletedAt.HasValue)
            {
                throw new FamilyHvoyaInvalidOperationException($"Размещение с идентификатором {id} уже удалено");
            }

            clientWriteRepository.Delete(targetStorage);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        async Task<ClientModel> IClientService.EditAsync(ClientRequestModel source, CancellationToken cancellationToken)
        {
            var targetStorage = await clientReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetStorage == null)
            {
                throw new FamilyHvoyaEntityNotFoundException<Client>(source.Id);
            }

            targetStorage.Surname = source.Surname;
            targetStorage.Name = source.Name;
            targetStorage.Patronymic = source.Patronymic;
            targetStorage.Password = source.Password;
            targetStorage.Email = source.Email;
            targetStorage.Phone = source.Phone;
            targetStorage.Gender = source.Gender;
            targetStorage.Birthday = source.Birthday;
            clientWriteRepository.Update(targetStorage);

            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<ClientModel>(targetStorage);
        }

        async Task<IEnumerable<ClientModel>> IClientService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await clientReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<ClientModel>>(result);
        }

        async Task<ClientModel?> IClientService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await clientReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new FamilyHvoyaEntityNotFoundException<Client>(id);
            }
            return mapper.Map<ClientModel>(item);
        }
    }
}
