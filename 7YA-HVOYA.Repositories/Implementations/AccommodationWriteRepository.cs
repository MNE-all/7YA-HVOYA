using _7YA_HVOYA.Common.Entity.InterfaceDB;
using _7YA_HVOYA.Context.Contracts.Models;
using _7YA_HVOYA.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Repositories.Implementations
{
    /// <inheritdoc cref="IAccommodationWriteRepository"/>
    public class AccommodationWriteRepository : BaseWriteRepository<Accommodation>,
        IAccommodationWriteRepository,
        IRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="AccommodationWriteRepository"/>
        /// </summary>
        public AccommodationWriteRepository(IDbWriterContext writerContext) : base(writerContext)
        {
        }
    }
}
