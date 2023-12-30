using _7YA_HVOYA.Common.Entity.InterfaceDB;
using _7YA_HVOYA.Common.Entity.Repositories;
using _7YA_HVOYA.Context.Contracts.Models;
using _7YA_HVOYA.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Repositories.Implementations
{
    public class OrderReadRepository : IOrderReadRepository, IRepositoryAnchor
    {
        private readonly IDbRead reader;

        public OrderReadRepository(IDbRead reader)
        {
            this.reader = reader;
            Log.Information("Инициализирован абстракция IDbReader в классе OrderReadRepository");
        }

        Task<IReadOnlyCollection<Order>> IOrderReadRepository.GetAllAsync(CancellationToken cancellationToken)
             => reader.Read<Order>()
                .NotDeletedAt()
                .OrderBy(x => x.Number)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<Order?> IOrderReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Order>()
                .ById(id)
                .FirstOrDefaultAsync(cancellationToken);

        Task<IReadOnlyCollection<Order>> IOrderReadRepository.GetByIdsAsync(int number, CancellationToken cancellation)
            => reader.Read<Order>()
                .Where(x => x.Number == number)
                .ToReadOnlyCollectionAsync(cancellation);
    }
}
