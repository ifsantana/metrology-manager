using System.Collections.Generic;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetActualPointsCollectionByNominalPointId.Models
{
    public class GetActualPointsCollectionByNominalPointIdQueryReturn
    {
        public List<ActualPointsCollectionByNominalPointIdReturnModel> ActualPointsCollection { get; set; }
    }
}
