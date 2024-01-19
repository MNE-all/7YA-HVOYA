using _7YA_HVOYA.API.Attribute;
using _7YA_HVOYA.API.Infrastructures.Validator;
using _7YA_HVOYA.API.Models;
using _7YA_HVOYA.API.ModelsRequest.Client;
using _7YA_HVOYA.Services.Contracts.Interface;
using _7YA_HVOYA.Services.Contracts.Models;
using _7YA_HVOYA.Services.Contracts.ModelsRequest;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace _7YA_HVOYA.API.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с Клиентами
    /// </summary>
    /// [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;
        private readonly IApiValidatorService validatorService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ClientController"/>
        /// </summary>
        public ClientController (IClientService clientService,
                                   IApiValidatorService validatorService,
                                   IMapper mapper)
        { 
            this.clientService = clientService;
            this.validatorService = validatorService;
            this.mapper = mapper;
        }
        /// <summary>
        /// Получить список всех клиентов
        /// </summary>
        [HttpGet]
        [ApiOk(typeof(IEnumerable<ClientResponse>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await clientService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<ClientResponse>>(result));
        }

        /// <summary>
        /// Получает клиента по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ApiOk(typeof(ClientResponse))]
        [ApiNotFound]
        public async Task<IActionResult> GetById([Required] Guid id, CancellationToken cancellationToken)
        {
            var result = await clientService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<ClientResponse>(result));
        }

        /// <summary>
        /// Создаёт нового клиента
        /// </summary>
        [HttpPost]
        [ApiOk(typeof(ClientResponse))]
        [ApiConflict]
        public async Task<IActionResult> Create(CreateClientRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var clientRequestModel = mapper.Map<ClientRequestModel>(request);
            var result = await clientService.AddAsync(clientRequestModel, cancellationToken);
            return Ok(mapper.Map<ClientResponse>(result));
        }

        /// <summary>
        /// Редактирует имеющегося клиента
        /// </summary>
        [HttpPut]
        [ApiOk(typeof(ClientResponse))]
        [ApiNotFound]
        [ApiConflict]
        public async Task<IActionResult> Edit(ClientRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var model = mapper.Map<ClientRequestModel>(request);
            var result = await clientService.EditAsync(model, cancellationToken);
            return Ok(mapper.Map<ClientResponse>(result));
        }

        /// <summary>
        /// Удаляет имеющегося клиента
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ApiOk(typeof(ClientResponse))]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await clientService.DeleteAsync(id, cancellationToken);
            return Ok();
        }

    }
}
