using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsByIdCollection.Interfaces;
using System;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsByIdCollection
{
    public class GetNominalPointsCollectionByIdQuery : IGetNominalPointsCollectionByIdQuery
    {
        public Guid Id { get; set; }
    }
}
