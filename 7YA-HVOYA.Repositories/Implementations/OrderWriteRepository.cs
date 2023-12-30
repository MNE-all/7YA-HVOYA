using _7YA_HVOYA.Common.Entity.InterfaceDB;
using _7YA_HVOYA.Context.Contracts.Models;
using _7YA_HVOYA.Repositories.Contracts;

namespace _7YA_HVOYA.Repositories.Implementations
{
    /// <inheritdoc cref="IOrderWriteRepository"/>
    public class OrderWriteRepository : BaseWriteRepository<Order>,
        IOrderWriteRepository,
        IRepositoryAnchor
    {
        /// <summary
        /// Инициализирует новый экземпляр <see cref="OrderWriteRepository"/>
        /// </summary>
        public OrderWriteRepository(IDbWriterContext writerContext) : base(writerContext)
        {
        }
    }
}
