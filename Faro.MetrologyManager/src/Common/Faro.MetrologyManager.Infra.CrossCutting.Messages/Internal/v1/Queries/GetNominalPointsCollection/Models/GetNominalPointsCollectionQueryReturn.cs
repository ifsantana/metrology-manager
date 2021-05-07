using System.Collections.Generic;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsCollection.Models
{
    public class GetNominalPointsCollectionQueryReturn
    {
        public List<GetNominalPointsCollectionQueryReturnModel> NominalPointsCollection { get; set; }
    }
}
