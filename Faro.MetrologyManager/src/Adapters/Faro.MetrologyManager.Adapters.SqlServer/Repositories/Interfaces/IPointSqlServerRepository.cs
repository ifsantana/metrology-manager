using Faro.MetrologyManager.Adapters.EntityFrameworkCore.Oracle.Repositories.Base.Interfaces;
using Faro.MetrologyManager.Domain.Entities.Points;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.EventHandlers.Base.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.QueryHandlers.Base.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.ActualPointAdded;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.ActualPointRemoved;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.PointAdded;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetActualPointsCollectionByNominalPointId;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetActualPointsCollectionByNominalPointId.Models;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsByIdCollection;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsByIdCollection.Models;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsCollection;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsCollection.Models;

namespace Faro.MetrologyManager.Adapters.SqlServer.Repositories.Interfaces
{
    public interface IPointSqlServerRepository : 
        ISqlServerRepository<Point>,
        IQueryHandler<GetNominalPointsCollectionQuery, GetNominalPointsCollectionQueryReturn>,
        IQueryHandler<GetNominalPointsCollectionByIdQuery, GetNominalPointsCollectionByIdQueryReturn>,
        IQueryHandler<GetActualPointsCollectionByNominalPointIdQuery, GetActualPointsCollectionByNominalPointIdQueryReturn>,
        IEventHandler<PointAddedEvent>,
        IEventHandler<ActualPointAddedEvent>,
        IEventHandler<ActualPointRemovedEvent>
    {
    }
}
