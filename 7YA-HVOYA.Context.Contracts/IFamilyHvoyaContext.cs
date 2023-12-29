using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using _7YA_HVOYA.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;


namespace _7YA_HVOYA.Context.Contracts
{
    /// <summary>
    /// Контекст работы с сущностями
    /// </summary>
    public interface IFamilyHvoyaContext
    {
        /// <summary>Список <inheritdoc cref="Thing"/></summary>
        DbSet<Thing> Things { get; }
        /// <summary>Список <inheritdoc cref="Storage"/></summary>
        DbSet<Storage> Storages { get; }
        /// <summary>Список <inheritdoc cref="Client"/></summary>
        DbSet<Client> Clients { get; }
        /// <summary>Список <inheritdoc cref="Cart"/></summary>
        DbSet<Cart> Carts { get; }
        /// <summary>Список <inheritdoc cref="Accommodation"/></summary>
        DbSet<Accommodation> Accommodations { get; }
        /// <summary>Список <inheritdoc cref="Order"/></summary>
        DbSet<Order> Orders { get; }

    }
}
