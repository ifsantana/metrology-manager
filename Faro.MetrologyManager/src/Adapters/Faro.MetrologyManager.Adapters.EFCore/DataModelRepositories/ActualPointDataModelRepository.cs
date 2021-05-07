using Faro.MetrologyManager.Adapters.EFCore.Contexts.Interfaces;
using Faro.MetrologyManager.Adapters.EFCore.DataModelRepositories.Base;
using Faro.MetrologyManager.Adapters.EFCore.DataModelRepositories.Interfaces;
using Faro.MetrologyManager.Adapters.EFCore.DataModels;
using Faro.MetrologyManager.Infra.CrossCutting.Adapters.Interfaces;
using Serilog;

namespace Faro.MetrologyManager.Adapters.EFCore.DataModelRepositories
{
    public class ActualPointDataModelRepository : DataModelRepositoryBase<ActualPointDataModel>, IActualPointDataModelRepository
    {
        public ActualPointDataModelRepository(ILogger logger, IAdapter adapter, IDbContext dbContext)
            : base(logger, adapter, dbContext)
        {
        }
    }
}
