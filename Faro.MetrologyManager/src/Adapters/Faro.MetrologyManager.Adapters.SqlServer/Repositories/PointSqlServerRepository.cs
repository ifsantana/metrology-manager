using Faro.MetrologyManager.Adapters.EFCore.DataModelRepositories.Interfaces;
using Faro.MetrologyManager.Adapters.EFCore.DataModels;
using Faro.MetrologyManager.Adapters.SqlServer.Repositories.Interfaces;
using Faro.MetrologyManager.Domain.Entities.Points;
using Faro.MetrologyManager.Infra.CrossCutting.Adapters.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.ActualPointAdded;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.ActualPointRemoved;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.PointAdded;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetActualPointsCollectionByNominalPointId;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetActualPointsCollectionByNominalPointId.Models;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsByIdCollection;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsByIdCollection.Models;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsCollection;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsCollection.Models;
using Faro.MetrologyManagerAdapters.EFCore.Oracle.Repositories.Base;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Faro.MetrologyManager.Adapters.SqlServer.Repositories
{
    public class PointSqlServerRepository : RepositoryBase<Point>, IPointSqlServerRepository
    {
        private readonly INominalPointDataModelRepository _nominalPointDataModelRepository;
        private readonly IActualPointDataModelRepository _actualPointDataModelRepository;

        public PointSqlServerRepository(ILogger logger, IBus bus, IAdapter adapter, INominalPointDataModelRepository nominalPointDataModelRepository,
            IActualPointDataModelRepository actualPointDataModelRepository) 
            : base(logger, bus, adapter)
        {
            _nominalPointDataModelRepository = nominalPointDataModelRepository;
            _actualPointDataModelRepository = actualPointDataModelRepository;
        }

        public override Task<Point> AddInternalAsync(Point entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Point>> GetAllInternalAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<Point> GetByIdInternalAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task RemoveInternalAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<Point> UpdateInternalAsync(Point entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task Handle(PointAddedEvent notification, CancellationToken cancellationToken)
        {
            var dataModel = Adapter.Adapt<NominalPointDataModel>(notification.AddedPoint);

            await _nominalPointDataModelRepository.AddAsync(dataModel, cancellationToken).ConfigureAwait(false);
        }

        public async Task<GetNominalPointsCollectionQueryReturn> Handle(GetNominalPointsCollectionQuery request, CancellationToken cancellationToken)
        {
            var resultData = new List<GetNominalPointsCollectionQueryReturnModel>();

            var nominalPoints = await _nominalPointDataModelRepository.GetAllAsync(cancellationToken).ConfigureAwait(false);

            foreach (var nominalPoint in nominalPoints)
            {
                var actuals = await _actualPointDataModelRepository.FindAsync(a => a.NominalPointId == nominalPoint.Id, cancellationToken).ConfigureAwait(false);

                var item = new GetNominalPointsCollectionQueryReturnModel()
                {
                    Id = nominalPoint.Id,
                    Name = nominalPoint.Name,
                    CreatedAt = nominalPoint.CreatedAt,
                    CreatedBy = nominalPoint.CreatedBy,
                    UpdatedAt = nominalPoint.UpdatedAt,
                    UpdatedBy = nominalPoint.UpdatedBy,
                    RowVersion = nominalPoint.RowVersion,
                    X = nominalPoint.X,
                    Y = nominalPoint.Y,
                    Z = nominalPoint.Z,
                    ActualPointsCollection = actuals.Select(a => new GetNominalPointsByIdActualPointsQueryReturnModel() 
                    { 
                        Id = a.Id, 
                        Name = a.Name, 
                        Y = a.Y, 
                        X = a.X,
                        Z = a.Z,
                        NominalPointId = a.NominalPointId
                    }).Cast<GetNominalPointsByIdActualPointsQueryReturnModel>().ToList()
                };

                resultData.Add(item);
            }

            return new GetNominalPointsCollectionQueryReturn { NominalPointsCollection = resultData };
        }

        public async Task Handle(ActualPointAddedEvent notification, CancellationToken cancellationToken)
        {
            var dataModel = Adapter.Adapt<ActualPointDataModel>(notification.AddedActualPoint);

            await _actualPointDataModelRepository.AddAsync(dataModel, cancellationToken).ConfigureAwait(false);
        }

        public async Task<GetNominalPointsCollectionByIdQueryReturn> Handle(GetNominalPointsCollectionByIdQuery request, CancellationToken cancellationToken)
        {
            var dataModel = await _nominalPointDataModelRepository.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

            var result = Adapter.Adapt<NominalPointsCollectionByIdQueryReturnModel>(dataModel);

            return new GetNominalPointsCollectionByIdQueryReturn { NominalPoint = result };
        }

        public async Task<GetActualPointsCollectionByNominalPointIdQueryReturn> Handle(GetActualPointsCollectionByNominalPointIdQuery request, CancellationToken cancellationToken)
        {
            var actualDataModel = await _actualPointDataModelRepository.FindAsync(a => a.NominalPointId == request.NominalPointId, cancellationToken).ConfigureAwait(false);

            var nominalDataModel = await _nominalPointDataModelRepository.GetByIdAsync(request.NominalPointId, cancellationToken).ConfigureAwait(false);

            var result = actualDataModel.Select(a => new ActualPointsCollectionByNominalPointIdReturnModel
            {
                Id = a.Id,
                Name = a.Name,
                CreatedAt = a.CreatedAt,
                CreatedBy = a.CreatedBy,
                UpdatedAt = a.UpdatedAt,
                UpdatedBy = a.UpdatedBy,
                RowVersion = a.RowVersion,
                NominalPointId = a.NominalPointId,
                NominalPoint = new NominalPointCollectionByNominalPointIdReturnModel { Name = nominalDataModel.Name, X = nominalDataModel.X, Y = nominalDataModel.Y, Z = nominalDataModel.Z },
                X = a.X,
                Y = a.Y,
                Z = a.Z
            }).Cast<ActualPointsCollectionByNominalPointIdReturnModel>().ToList();

            return new GetActualPointsCollectionByNominalPointIdQueryReturn { ActualPointsCollection = result };
        }

        public async Task Handle(ActualPointRemovedEvent notification, CancellationToken cancellationToken)
        {
            await _actualPointDataModelRepository.RemoveAsync(notification.RemovedActualPoint.Id, cancellationToken).ConfigureAwait(false);
        }
    }
}
