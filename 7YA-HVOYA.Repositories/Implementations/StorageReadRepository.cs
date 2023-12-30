using Microsoft.EntityFrameworkCore;
using Serilog;
using _7YA_HVOYA.Common.Entity.InterfaceDB;
using _7YA_HVOYA.Common.Entity.Repositories;
using _7YA_HVOYA.Context.Contracts.Models;
using _7YA_HVOYA.Repositories.Contracts;

namespace _7YA_HVOYA.Repositories.Implementations
{
    public class StorageReadRepository : IStorageReadRepository, IRepositoryAnchor
    {
        private readonly IDbRead reader;

        public StorageReadRepository(IDbRead reader)
        {
            this.reader = reader;
            Log.Information("Инициализирован абстракция IDbReader в классе DisciplineReadRepository");
        }
        Task<IReadOnlyCollection<Storage>> IStorageReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<Storage>()
                .NotDeletedAt()
                .OrderBy(x => x.Name)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<Storage?> IStorageReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken) 
            => reader.Read<Storage>()
                .ById(id)
                .FirstOrDefaultAsync(cancellationToken);

        Task<Dictionary<Guid, Storage>> IStorageReadRepository.GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
            => reader.Read<Storage>()
                .NotDeletedAt()
                .ByIds(ids)
                .OrderBy(x => x.Name)
                .ToDictionaryAsync(key => key.Id, cancellationToken);
    }
}
