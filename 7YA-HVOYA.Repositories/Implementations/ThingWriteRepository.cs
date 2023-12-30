using _7YA_HVOYA.Common.Entity.InterfaceDB;
using _7YA_HVOYA.Context.Contracts.Models;
using _7YA_HVOYA.Repositories.Contracts;

namespace _7YA_HVOYA.Repositories.Implementations
{
    public class ThingWriteRepository : BaseWriteRepository<Thing>,
        IThingWriteRepository,
        IRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="DisciplineWriteRepository"/>
        /// </summary>
        public ThingWriteRepository(IDbWriterContext writerContext) : base(writerContext)
        {
        }
    }
}
