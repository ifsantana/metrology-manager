using Faro.MetrologyManager.Infra.CrossCutting.Bus.Messages.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetActualPointsCollectionByNominalPointId.Models;
using System;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetActualPointsCollectionByNominalPointId.Interfaces
{
    public interface IGetActualPointsCollectionByNominalPointIdQuery : IQuery<GetActualPointsCollectionByNominalPointIdQueryReturn>
    {
        Guid NominalPointId { get; set; }
    }
}
