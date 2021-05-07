using Faro.MetrologyManager.Domain.Entities.Points;
using Faro.MetrologyManager.Domain.Services.Base.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Faro.MetrologyManager.Domain.Services.Interfaces
{
    public interface IPointService : IService<Point>
    {
        Task<(bool sucess, Point addedPoint, bool isNewPoint)> AddOrUpdateNewPoint(Point point, CancellationToken cancellationToken);

        Task<(bool sucess, Point addedPoint)> RemovePoint(Point point, CancellationToken cancellationToken);

        Task<(bool sucess, ActualPoint addedActualPoint)> AddOrUpdateNewActualPoint(ActualPoint point, Guid nominalPointId, CancellationToken cancellationToken);

        Task<(bool sucess, ActualPoint removedActualPoint)> RemoveActualPoint(ActualPoint point, CancellationToken cancellationToken);
    }
}
