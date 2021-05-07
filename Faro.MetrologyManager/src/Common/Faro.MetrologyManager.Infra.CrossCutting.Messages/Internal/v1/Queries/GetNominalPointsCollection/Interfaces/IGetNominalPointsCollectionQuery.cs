using Faro.MetrologyManager.Infra.CrossCutting.Bus.Messages.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsCollection.Models;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsCollection.Interfaces
{
    public interface IGetNominalPointsCollectionQuery : IQuery<GetNominalPointsCollectionQueryReturn>
    {
    }
}
