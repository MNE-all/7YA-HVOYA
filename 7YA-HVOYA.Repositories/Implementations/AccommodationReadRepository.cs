using _7YA_HVOYA.Common.Entity.InterfaceDB;
using _7YA_HVOYA.Common.Entity.Repositories;
using _7YA_HVOYA.Context.Contracts.Models;
using _7YA_HVOYA.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Repositories.Implementations
{
    public class AccommodationReadRepository : IAccommodationReadRepository, IRepositoryAnchor
    {
        private readonly IDbRead reader;

        public AccommodationReadRepository(IDbRead reader)
        {
            this.reader = reader;
            Log.Information("Инициализирован абстракция IDbReader в классе AccommodationReadRepository");
        }

        public Task<IReadOnlyCollection<Accommodation>> GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<Accommodation>()
                .NotDeletedAt()
                .OrderBy(x => x.StorageId)
                .ToReadOnlyCollectionAsync(cancellationToken);

        public Task<IReadOnlyCollection<Accommodation>> GetAllByStorageNameAsync(string storageName, CancellationToken cancellationToken)
            => reader.Read<Accommodation>()
                .NotDeletedAt()
                .Where(x => x.Storage.Name == storageName)
                .OrderBy(x => x.ThingId)
                .ToReadOnlyCollectionAsync(cancellationToken);


        public Task<Accommodation?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Accommodation>()
                .ById(id)
                .FirstOrDefaultAsync(cancellationToken);
    }
}
