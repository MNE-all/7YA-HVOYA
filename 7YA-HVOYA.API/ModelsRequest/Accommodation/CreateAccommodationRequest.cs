using _7YA_HVOYA.Services.Contracts.Models;

namespace _7YA_HVOYA.API.ModelsRequest.Accommodation
{
    public class CreateAccommodationRequest
    {
        /// <summary>
        /// <inheritdoc cref="StorageModel"/>
        /// </summary>
        public Guid Storage { get; set; }

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
