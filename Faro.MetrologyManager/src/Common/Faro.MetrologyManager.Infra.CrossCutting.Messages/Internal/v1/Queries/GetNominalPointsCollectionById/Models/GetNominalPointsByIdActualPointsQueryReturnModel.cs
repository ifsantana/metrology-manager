using System;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsCollection.Models
{
    public class GetNominalPointsByIdActualPointsQueryReturnModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }
        public Guid NominalPointId { get; set; }
    }
}
