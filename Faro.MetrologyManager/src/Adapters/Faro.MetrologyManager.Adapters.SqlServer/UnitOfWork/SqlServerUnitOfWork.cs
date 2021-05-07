using Faro.MetrologyManager.Adapters.EFCore.Contexts.Interfaces;
using Faro.MetrologyManager.Adapters.SqlServer.UnitOfWork.Interfaces;
using Serilog;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Faro.MetrologyManager.Adapters.SqlServer.UnitOfWork
{
    public class SqlServerUnitOfWork : ISqlServerUnitOfWork
    {
        private readonly IDbContext _dbContext;
        private readonly ILogger _logger;

        public SqlServerUnitOfWork(IDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> ExecuteWithTransactionAsync(Func<Task<bool>> handleAsync, CancellationToken cancellationToken, IDbConnection dbConnection = null, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            try
            {
                if (await handleAsync())
                {
                    await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            };
        }
    }
}
