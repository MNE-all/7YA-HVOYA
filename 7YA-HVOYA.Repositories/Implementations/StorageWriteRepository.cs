using _7YA_HVOYA.Common.Entity.InterfaceDB;
using _7YA_HVOYA.Context.Contracts.Models;
using _7YA_HVOYA.Repositories.Contracts;

namespace _7YA_HVOYA.Repositories.Implementations
{
    public class StorageWriteRepository : BaseWriteRepository<Storage>,
        IStorageWriteRepository,
        IRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="StorageWriteRepository"/>
        /// </summary>
        public StorageWriteRepository(IDbWriterContext writerContext)
            : base(writerContext)
        {

        }
    }
}
