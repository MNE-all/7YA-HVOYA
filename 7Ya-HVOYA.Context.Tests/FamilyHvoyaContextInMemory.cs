using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using _7YA_HVOYA.Common.Entity.InterfaceDB;

namespace _7YA_HVOYA.Context.Tests
{
    /// <summary>
    /// Класс <see cref="FamilyHvoyaContext"/> для тестов с базой в памяти. Один контекст на тест
    /// </summary>
    public abstract class FamilyHvoyaContextInMemory : IAsyncDisposable
    {
        protected readonly CancellationToken CancellationToken;
        private readonly CancellationTokenSource cancellationTokenSource;

        /// <summary>
        /// Контекст <see cref="TimeTableContext"/>
        /// </summary>
        protected FamilyHvoyaContext Context { get; }

        /// <inheritdoc cref="IUnitOfWork"/>
        protected IUnitOfWork UnitOfWork => Context;

        /// <inheritdoc cref="IDbRead"/>
        protected IDbRead Reader => Context;

        protected IDbWriterContext WriterContext => new TestWriterContext(Context, UnitOfWork);

        protected FamilyHvoyaContextInMemory()
        {
            cancellationTokenSource = new CancellationTokenSource();
            CancellationToken = cancellationTokenSource.Token;
            var optionsBuilder = new DbContextOptionsBuilder<FamilyHvoyaContext>()
                .UseInMemoryDatabase($"MoneronTests{Guid.NewGuid()}")
                .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            Context = new FamilyHvoyaContext(optionsBuilder.Options);
        }

        /// <inheritdoc cref="IDisposable"/>
        public async ValueTask DisposeAsync()
        {
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
            try
            {
                await Context.Database.EnsureDeletedAsync();
                await Context.DisposeAsync();
            }
            catch (ObjectDisposedException ex)
            {
                Trace.TraceError(ex.Message);
            }
        }
    }
}
