using _7YA_HVOYA.Services.Contracts.Models;

namespace _7YA_HVOYA.API.ModelsRequest.Cart
{
    public class CreateCartRequest
    {
        /// <summary>
        /// <inheritdoc cref="ClientModel"/>
        /// </summary>
        public Guid Client { get; set; }
        /// <summary>
        /// <inheritdoc cref="ThingModel"/>
        /// </summary>
        public Guid Thing { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public int Amount { get; set; }
    }
}
