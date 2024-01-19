using _7YA_HVOYA.API.Attribute;
using _7YA_HVOYA.API.Infrastructures.Validator;
using _7YA_HVOYA.API.Models;
using _7YA_HVOYA.API.ModelsRequest.Accommodation;
using _7YA_HVOYA.API.ModelsRequest.Cart;
using _7YA_HVOYA.Services.Contracts.Interface;
using _7YA_HVOYA.Services.Contracts.Models;
using _7YA_HVOYA.Services.Implementations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace _7YA_HVOYA.API.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с элементами корзины
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Cart")]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;
        private readonly IApiValidatorService validatorService;
        private readonly IMapper mapper;


        /// <summary>
        /// Инициализирует новый экземпляр <see cref="CartController"/>
        /// </summary>
        public CartController (ICartService cartService,
                               IApiValidatorService validatorService,
                               IMapper mapper)
        {
            this.cartService = cartService;
            this.validatorService = validatorService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Получить список всех элементов корзины
        /// </summary>
        [HttpGet]
        [ApiOk(typeof(IEnumerable<CartResponse>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await cartService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<CartResponse>>(result));
        }

        /// <summary>
        /// Получает элемент корзины по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ApiOk(typeof(CartResponse))]
        [ApiNotFound]
        public async Task<IActionResult> GetById([Required] Guid id, CancellationToken cancellationToken)
        {
            var result = await cartService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<CartResponse>(result));
        }

        /// <summary>
        /// Создаёт новое элемент корзины
        /// </summary>
        [HttpPost]
        [ApiOk(typeof(CartResponse))]
        [ApiConflict]
        public async Task<IActionResult> Create(CreateCartRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var model = mapper.Map<CartModel>(request);
            var result = await cartService.AddAsync(model, cancellationToken);
            return Ok(mapper.Map<CartResponse>(result));
        }

        /// <summary>
        /// Редактирует имеющийся элемент корзины
        /// </summary>
        [HttpPut]
        [ApiOk(typeof(CartResponse))]
        [ApiNotFound]
        [ApiConflict]
        public async Task<IActionResult> Edit(CartRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var model = mapper.Map<CartModel>(request);
            var result = await cartService.EditAsync(model, cancellationToken);
            return Ok(mapper.Map<CartResponse>(result));
        }

        /// <summary>
        /// Удаляет имеющийся элемент корзины
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ApiOk(typeof(CartResponse))]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await cartService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
