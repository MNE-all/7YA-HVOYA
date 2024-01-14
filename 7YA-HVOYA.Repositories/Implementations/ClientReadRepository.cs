using _7YA_HVOYA.Common.Entity.InterfaceDB;
using _7YA_HVOYA.Common.Entity.Repositories;
using _7YA_HVOYA.Context.Contracts.Models;
using _7YA_HVOYA.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace _7YA_HVOYA.Repositories.Implementations
{
    public class ClientReadRepository : IClientReadRepository, IRepositoryAnchor
    {
        private readonly IDbRead reader;

        public ClientReadRepository(IDbRead reader)
        {
            this.reader = reader;
            Log.Information("Инициализирован абстракция IDbReader в классе DisciplineReadRepository");
        }

        public Task<IReadOnlyCollection<Client>> GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<Client>()
                .NotDeletedAt()
                .OrderBy(x => x.Name)
                .ToReadOnlyCollectionAsync(cancellationToken);

        public Task<Client?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Client>()
                .ById(id)
                .FirstOrDefaultAsync(cancellationToken);
    }
}
