using _7YA_HVOYA.Context.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _7YA_HVOYA.Repositories.Contracts
{
    /// <summary>
    /// Репозиторий записи <see cref="Order"/>
    /// </summary>
    public interface IOrderWriteRepository : IRepositoryWriter<Order>
    {
    }
}
