using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetActualPointsCollectionByNominalPointId.Interfaces;
using System;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetActualPointsCollectionByNominalPointId
{
    public class GetActualPointsCollectionByNominalPointIdQuery : IGetActualPointsCollectionByNominalPointIdQuery
    {
        public Guid NominalPointId { get; set; }
    }
}
