using Faro.MetrologyManager.Infra.CrossCutting.Bus.Messages.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsByIdCollection.Models;
using System;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsByIdCollection.Interfaces
{
    public interface IGetNominalPointsCollectionByIdQuery : IQuery<GetNominalPointsCollectionByIdQueryReturn>    
    {
        Guid Id { get; set; }
    }
}
