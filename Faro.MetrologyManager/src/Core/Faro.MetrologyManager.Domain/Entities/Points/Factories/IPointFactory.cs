using Faro.MetrologyManager.Infra.CrossCutting.Factories.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsByIdCollection.Models;

namespace Faro.MetrologyManager.Domain.Entities.Points.Factories
{
    public interface IPointFactory :
        IFactoryWithParameter<Point, string>,
        IFactoryWithParameter<Point, GetNominalPointsCollectionByIdQueryReturn>
    {
    }
}
