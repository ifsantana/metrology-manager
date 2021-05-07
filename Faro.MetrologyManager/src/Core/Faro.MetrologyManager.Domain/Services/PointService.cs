using Faro.MetrologyManager.Domain.Entities.Points;
using Faro.MetrologyManager.Domain.Services.Base;
using Faro.MetrologyManager.Domain.Services.Interfaces;
using Faro.MetrologyManager.Domain.Validators.Points.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Adapters.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsByIdCollection;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsByIdCollection.Models;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Faro.MetrologyManager.Domain.Services
{
    public class PointService : ServiceBase, IPointService
    {
        private readonly IIsPointValidToAddOrUpdateValidator _isPointValidToAddOrUpdateValidator;
        private readonly IIsActualPointValidToAddOrUpdateValidator _isActualPointValidToAddOrUpdateValidator;
        
        public PointService(ILogger logger, IBus bus, IAdapter adapter, IIsPointValidToAddOrUpdateValidator isPointValidToAddOrUpdateValidator,
                           IIsActualPointValidToAddOrUpdateValidator isActualPointValidToAddOrUpdateValidator) 
            : base(logger, bus, adapter)
        {
            _isPointValidToAddOrUpdateValidator = isPointValidToAddOrUpdateValidator;
            _isActualPointValidToAddOrUpdateValidator = isActualPointValidToAddOrUpdateValidator;
        }

        public async Task<(bool sucess, ActualPoint addedActualPoint)> AddOrUpdateNewActualPoint(ActualPoint point, Guid nominalPointId, CancellationToken cancellationToken)
        {
            if (!await CheckValidationResultAndSendDomainNotificationsAsync(nameof(AddOrUpdateNewActualPoint),
                new[] { _isActualPointValidToAddOrUpdateValidator.Validate(point) },
                cancellationToken).ConfigureAwait(false))
            {
                return (false, default);
            }

            var pointByIdQueryReturn = await Bus.SendQueryAsync<GetNominalPointsCollectionByIdQuery, GetNominalPointsCollectionByIdQueryReturn>(
                Adapter.Adapt<GetNominalPointsCollectionByIdQuery>(new GetNominalPointsCollectionByIdQuery { Id = nominalPointId }),
                cancellationToken
            ).ConfigureAwait(false);

            point.SetNominalPoint(Adapter.Adapt<Point>(pointByIdQueryReturn.NominalPoint));

            return (true, point);
        }

        public async Task<(bool sucess, Point addedPoint, bool isNewPoint)> AddOrUpdateNewPoint(Point point, CancellationToken cancellationToken)
        {
            if (!await CheckValidationResultAndSendDomainNotificationsAsync(nameof(AddOrUpdateNewPoint),
                new[] { _isPointValidToAddOrUpdateValidator.Validate(point) },
                cancellationToken).ConfigureAwait(false))
            {
                return (false, default, false);
            }

            return (true, point, true);
        }

        public Task<(bool sucess, ActualPoint removedActualPoint)> RemoveActualPoint(ActualPoint point, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<(bool sucess, Point addedPoint)> RemovePoint(Point point, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
