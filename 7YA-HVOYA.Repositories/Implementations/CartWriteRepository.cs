using _7YA_HVOYA.Common.Entity.InterfaceDB;
using _7YA_HVOYA.Context.Contracts.Models;
using _7YA_HVOYA.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Repositories.Implementations
{
    public class CartWriteRepository : BaseWriteRepository<Cart>,
        ICartWriteRepository,
        IRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="CartWriteRepository"/>
        /// </summary>
        public CartWriteRepository(IDbWriterContext writerContext)
            : base(writerContext)
        {

        }
    }
}
