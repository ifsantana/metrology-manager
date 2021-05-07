using Faro.MetrologyManager.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Faro.MetrologyManager.Adapters.EntityFrameworkCore.Oracle.Repositories.Base.Interfaces
{
    public interface ISqlServerRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity> AddInternalAsync(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> UpdateInternalAsync(TEntity entity, CancellationToken cancellationToken);
        Task RemoveInternalAsync(Guid id, CancellationToken cancellationToken);
        Task<TEntity> GetByIdInternalAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> GetAllInternalAsync(CancellationToken cancellationToken);
    }
}
