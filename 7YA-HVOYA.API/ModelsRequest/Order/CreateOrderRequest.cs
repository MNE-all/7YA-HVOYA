using _7YA_HVOYA.Services.Contracts.Models;

namespace _7YA_HVOYA.API.ModelsRequest.Order
{
    public class CreateOrderRequest
    {
        /// <summary>
        /// Номер заказа
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// <inheritdoc cref="ThingModel"/>
        /// </summary>
        public Guid ThingId { get; set; }
        /// <summary>

        /// <summary>
        /// Количество
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        ///  <inheritdoc cref="ClientModel"/>
        /// </summary>
        public Guid ClientId { get; set; }
    }
}
