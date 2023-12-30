using _7YA_HVOYA.Common.Entity.InterfaceDB;
using _7YA_HVOYA.Common.Entity.Repositories;
using _7YA_HVOYA.Context.Contracts.Emuns;
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
    public class ThingReadRepository : IThingReadRepository, IRepositoryAnchor
    {
        private readonly IDbRead reader;

        public ThingReadRepository(IDbRead reader)
        {
            this.reader = reader;
            Log.Information("Инициализирован абстракция IDbReader в классе DisciplineReadRepository");
        }

        public Task<IReadOnlyCollection<Thing>> GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<Thing>()
                .NotDeletedAt()
                .OrderBy(x => x.Category)
                .ToReadOnlyCollectionAsync(cancellationToken);

        public Task<IReadOnlyCollection<Thing>> GetAllByCategoryAsync(Categories category, CancellationToken cancellationToken)
            => reader.Read<Thing>()
                .Where(x => x.Category == category)
                .ToReadOnlyCollectionAsync(cancellationToken);

        public Task<Thing?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Thing>()
                .ById(id)
                .FirstOrDefaultAsync(cancellationToken);
    }
}
