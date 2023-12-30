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
using System.Threading;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Repositories.Implementations
{
    public class CartReadRepository : ICartReadRepository, IRepositoryAnchor
    {
        private readonly IDbRead reader;
        public CartReadRepository(IDbRead reader)
        {
            this.reader = reader;
            Log.Information("Инициализирован абстракция IDbReader в классе DisciplineReadRepository");
        }
        public Task<IReadOnlyCollection<Cart>> GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<Cart>()
                .NotDeletedAt()
                .OrderBy(x => x.ClientId)
                .ToReadOnlyCollectionAsync(cancellationToken);

        public Task<IReadOnlyCollection<Cart>> GetByClientIdAsync(Guid clientId, CancellationToken cancellation)
             => reader.Read<Cart>().Where(x => x.ClientId == clientId).ToReadOnlyCollectionAsync(cancellation);

        public Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken) 
            => reader.Read<Cart>()
                .ById(id)
                .FirstOrDefaultAsync(cancellationToken);

    }
}
