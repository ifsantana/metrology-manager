using Faro.MetrologyManager.Ports.Api.Controllers.v1.Point.Responses.GetNominalPointsCollection.Models;
using System.Collections.Generic;

namespace Faro.MetrologyManager.Ports.Api.Controllers.v1.Point.Responses
{
    public class GetNominalPointsCollectionResponse
    {
        public List<NominalPointResponseModel> NominalPointsCollection { get; set; }
    }
}
