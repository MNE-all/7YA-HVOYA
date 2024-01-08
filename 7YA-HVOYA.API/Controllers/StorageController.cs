using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using _7YA_HVOYA.API.Attribute;
using _7YA_HVOYA.API.Infrastructures.Validator;
using _7YA_HVOYA.API.Models;
using _7YA_HVOYA.API.ModelsRequest.Storage;
using _7YA_HVOYA.Services.Contracts.Interface;
using _7YA_HVOYA.Services.Contracts.Models;

namespace _7YA_HVOYA.API.Controllers
{
    /// <summary>
    /// CRUD контроллер по работы со складами
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Storage")]
    public class StorageController : ControllerBase
    {
        private readonly IStorageService storageService;
        private readonly IApiValidatorService validatorService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="StorageController"/>
        /// </summary>
        public StorageController(IStorageService storageService,
            IMapper mapper,
            IApiValidatorService validatorService)
        {
            this.storageService = storageService;
            this.mapper = mapper;
            this.validatorService = validatorService;
        }


        /// <summary>
        /// Получить список всех складов
        /// </summary>
        [HttpGet]
        [ApiOk(typeof(IEnumerable<StorageResponse>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await storageService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<StorageResponse>>(result));
        }

        /// <summary>
        /// Получает склад по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ApiOk(typeof(StorageResponse))]
        [ApiNotFound]
        public async Task<IActionResult> GetById([Required] Guid id, CancellationToken cancellationToken)
        {
            var result = await storageService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<StorageResponse>(result));
        }

        /// <summary>
        /// Создаёт новый склад
        /// </summary>
        [HttpPost]
        [ApiOk(typeof(StorageResponse))]
        [ApiConflict]
        public async Task<IActionResult> Create(CreateStorageRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var result = await storageService.AddAsync(request.Name, request.Address, cancellationToken);
            return Ok(mapper.Map<StorageResponse>(result));
        }

        /// <summary>
        /// Редактирует имеющийся склад
        /// </summary>
        [HttpPut]
        [ApiOk(typeof(StorageResponse))]
        [ApiNotFound]
        [ApiConflict]
        public async Task<IActionResult> Edit(StorageRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var model = mapper.Map<StorageModel>(request);
            var result = await storageService.EditAsync(model, cancellationToken);
            return Ok(mapper.Map<StorageResponse>(result));
        }

        /// <summary>
        /// Удаляет имеющийся склад
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ApiOk(typeof(StorageResponse))]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await storageService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
