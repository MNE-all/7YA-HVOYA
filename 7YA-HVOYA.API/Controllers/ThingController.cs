using _7YA_HVOYA.API.Attribute;
using _7YA_HVOYA.API.Infrastructures.Validator;
using _7YA_HVOYA.API.Models;
using _7YA_HVOYA.API.ModelsRequest.Storage;
using _7YA_HVOYA.API.ModelsRequest.Thing;
using _7YA_HVOYA.Services.Contracts.Interface;
using _7YA_HVOYA.Services.Contracts.Models;
using _7YA_HVOYA.Services.Implementations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace _7YA_HVOYA.API.Controllers
{
    /// <summary>
    /// CRUD контроллер по работы с вещами
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Thing")]
    public class ThingController : ControllerBase
    {
        private readonly IThingService thingService;
        private readonly IApiValidatorService validatorService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует класс <inheritdoc cref="ThingController"/>
        /// </summary>
        /// <param name="thingService">Сервис вещей</param>
        /// <param name="validatorService">Сервис валидации</param>
        /// <param name="mapper">Маппер</param>
        public ThingController(IThingService thingService,
                               IApiValidatorService validatorService,
                               IMapper mapper)
        {
            this.thingService = thingService;
            this.mapper = mapper;
            this.validatorService = validatorService;
        }


        /// <summary>
        /// Получить список всех вещей
        /// </summary>
        [HttpGet]
        [ApiOk(typeof(IEnumerable<ThingResponse>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await thingService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<ThingResponse>>(result));
        }

        /// <summary>
        /// Получает вещь по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ApiOk(typeof(ThingResponse))]
        [ApiNotFound]
        public async Task<IActionResult> GetById([Required] Guid id, CancellationToken cancellationToken)
        {
            var result = await thingService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<ThingResponse>(result));
        }

        /// <summary>
        /// Создаёт новую вещь
        /// </summary>
        [HttpPost]
        [ApiOk(typeof(ThingResponse))]
        [ApiConflict]
        public async Task<IActionResult> Create(CreateThingRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var model = mapper.Map<ThingModel>(request);

            var result = await thingService.AddAsync(model, cancellationToken);
            return Ok(mapper.Map<ThingResponse>(result));
        }

        /// <summary>
        /// Редактирует имеющуюся вешь
        /// </summary>
        [HttpPut]
        [ApiOk(typeof(ThingResponse))]
        [ApiNotFound]
        [ApiConflict]
        public async Task<IActionResult> Edit(ThingRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var model = mapper.Map<ThingModel>(request);
            var result = await thingService.EditAsync(model, cancellationToken);
            return Ok(mapper.Map<ThingResponse>(result));
        }

        /// <summary>
        /// Удаляет имеющуюся вешь
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ApiOk(typeof(ThingResponse))]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await thingService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
