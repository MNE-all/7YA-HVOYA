using _7YA_HVOYA.API.Attribute;
using _7YA_HVOYA.API.Infrastructures.Validator;
using _7YA_HVOYA.API.Models;
using _7YA_HVOYA.API.ModelsRequest.Accommodation;
using _7YA_HVOYA.API.ModelsRequest.Client;
using _7YA_HVOYA.Services.Contracts.Interface;
using _7YA_HVOYA.Services.Contracts.Models;
using _7YA_HVOYA.Services.Contracts.ModelsRequest;
using _7YA_HVOYA.Services.Implementations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace _7YA_HVOYA.API.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с размещениями
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Accommodation")]
    public class AccommodationController : ControllerBase
    {
        private readonly IAccommodationService accommodationService;
        private readonly IApiValidatorService validatorService;
        private readonly IMapper mapper;


        /// <summary>
        /// Инициализирует новый экземпляр <see cref="AccommodationController"/>
        /// </summary>
        public AccommodationController(IAccommodationService accommodationService,
                              IApiValidatorService validatorService,
                              IMapper mapper)
        {
            this.accommodationService = accommodationService;
            this.validatorService = validatorService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Получить список всех размещений
        /// </summary>
        [HttpGet]
        [ApiOk(typeof(IEnumerable<AccommodationResponse>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await accommodationService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<AccommodationResponse>>(result));
        }

        /// <summary>
        /// Получает размещение по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ApiOk(typeof(AccommodationResponse))]
        [ApiNotFound]
        public async Task<IActionResult> GetById([Required] Guid id, CancellationToken cancellationToken)
        {
            var result = await accommodationService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<AccommodationResponse>(result));
        }

        /// <summary>
        /// Создаёт новое размещение
        /// </summary>
        [HttpPost]
        [ApiOk(typeof(AccommodationResponse))]
        [ApiConflict]
        public async Task<IActionResult> Create(CreateAccommodationRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var model = mapper.Map<AccommodationModel>(request);
            var result = await accommodationService.AddAsync(model, cancellationToken);
            return Ok(mapper.Map<AccommodationResponse>(result));
        }

        /// <summary>
        /// Редактирует имеющееся размещение
        /// </summary>
        [HttpPut]
        [ApiOk(typeof(AccommodationResponse))]
        [ApiNotFound]
        [ApiConflict]
        public async Task<IActionResult> Edit(AccommodationRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var model = mapper.Map<AccommodationModel>(request);
            var result = await accommodationService.EditAsync(model, cancellationToken);
            return Ok(mapper.Map<AccommodationResponse>(result));
        }

        /// <summary>
        /// Удаляет имеющееся размещение
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ApiOk(typeof(AccommodationResponse))]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await accommodationService.DeleteAsync(id, cancellationToken);
            return Ok();
        }


    }
}
