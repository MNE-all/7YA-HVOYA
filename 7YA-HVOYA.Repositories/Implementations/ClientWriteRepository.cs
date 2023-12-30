using _7YA_HVOYA.Common.Entity.InterfaceDB;
using _7YA_HVOYA.Context.Contracts.Models;
using _7YA_HVOYA.Repositories.Contracts;
namespace _7YA_HVOYA.Repositories.Implementations
{
    /// <inheritdoc cref="IClientWriteRepository"/>

    public class ClientWriteRepository : BaseWriteRepository<Client>,
        IClientWriteRepository,
        IRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ClientWriteRepository"/>
        /// </summary>
        public ClientWriteRepository(IDbWriterContext writerContext) : base(writerContext)
        {
        }
    }
}   
