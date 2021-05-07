using Faro.MetrologyManager.Adapters.EntityFrameworkCore.Oracle.Repositories.Base.Interfaces;
using Faro.MetrologyManager.Domain.Entities.Base;
using Faro.MetrologyManager.Infra.CrossCutting.Adapters.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Faro.MetrologyManagerAdapters.EFCore.Oracle.Repositories.Base
{
    public abstract class RepositoryBase<TEntity> : ISqlServerRepository<TEntity>
        where TEntity : IEntity
    {
        protected ILogger Logger { get; }
        protected IBus Bus { get; }
        protected IAdapter Adapter { get; }

        protected RepositoryBase(ILogger logger, IBus bus, IAdapter adapter)
        {
            Logger = logger;
            Bus = bus;
            Adapter = adapter;
        }

        public abstract Task<TEntity> AddInternalAsync(TEntity entity, CancellationToken cancellationToken);
        public abstract Task<TEntity> UpdateInternalAsync(TEntity entity, CancellationToken cancellationToken);
        public abstract Task RemoveInternalAsync(Guid id, CancellationToken cancellationToken);
        public abstract Task<TEntity> GetByIdInternalAsync(Guid id, CancellationToken cancellationToken);
        public abstract Task<IEnumerable<TEntity>> GetAllInternalAsync(CancellationToken cancellationToken);
    }
}
