using Faro.MetrologyManager.Ports.Api.Controllers.v1.Point.Responses.GetActualPointsByNominalPointIdCollection.Models;
using System.Collections.Generic;

namespace Faro.MetrologyManager.Ports.Api.Controllers.v1.Point.Responses.GetActualPointsByNominalPointIdCollection
{
    public class GetActualPointsByNominalPointIdCollectionResponse
    {
        public List<ActualPointModelResponse> ActualPointsCollection { get; set; }
    }
}
