﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Faro.MetrologyManager.Adapters.EFCore.DataModelRepositories.Base.Interfaces
{
    public interface IDataModelRepository<T>
    {
        Task<T> AddAsync(T dataModel, CancellationToken cancellationToken);
        Task<T> UpdateAsync(T dataModel, CancellationToken cancellationToken);
        Task RemoveAsync(Guid id, CancellationToken cancellationToken);
        Task RemoveAsync(T dataModel, CancellationToken cancellationToken);
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
    }
}
