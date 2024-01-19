using _7YA_HVOYA.API.Attribute;
using _7YA_HVOYA.API.Infrastructures.Validator;
using _7YA_HVOYA.API.Models;
using _7YA_HVOYA.API.ModelsRequest.Accommodation;
using _7YA_HVOYA.API.ModelsRequest.Order;
using _7YA_HVOYA.Services.Contracts.Interface;
using _7YA_HVOYA.Services.Contracts.Models;
using _7YA_HVOYA.Services.Implementations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace _7YA_HVOYA.API.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с заказами
    /// </summary>
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IApiValidatorService validatorService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="OrderController"/>
        /// </summary>
        public OrderController (IOrderService orderService,
                                IApiValidatorService validatorService,
                                IMapper mapper)
        {
            this.orderService = orderService;
            this.validatorService = validatorService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Получить список всех заказов
        /// </summary>
        [HttpGet]
        [ApiOk(typeof(IEnumerable<OrderResponse>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await orderService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<OrderResponse>>(result));
        }

        /// <summary>
        /// Получает заказ по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ApiOk(typeof(OrderResponse))]
        [ApiNotFound]
        public async Task<IActionResult> GetById([Required] Guid id, CancellationToken cancellationToken)
        {
            var result = await orderService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<OrderResponse>(result));
        }

        /// <summary>
        /// Создаёт новый заказ
        /// </summary>
        [HttpPost]
        [ApiOk(typeof(OrderResponse))]
        [ApiConflict]
        public async Task<IActionResult> Create(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var model = mapper.Map<OrderModel>(request);
            var result = await orderService.AddAsync(model, cancellationToken);
            return Ok(mapper.Map<OrderResponse>(result));
        }

        /// <summary>
        /// Редактирует имеющийся заказ
        /// </summary>
        [HttpPut]
        [ApiOk(typeof(OrderResponse))]
        [ApiNotFound]
        [ApiConflict]
        public async Task<IActionResult> Edit(OrderRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var model = mapper.Map<OrderModel>(request);
            var result = await orderService.EditAsync(model, cancellationToken);
            return Ok(mapper.Map<OrderResponse>(result));
        }

        /// <summary>
        /// Удаляет имеющийся заказ
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ApiOk(typeof(OrderResponse))]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await orderService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
