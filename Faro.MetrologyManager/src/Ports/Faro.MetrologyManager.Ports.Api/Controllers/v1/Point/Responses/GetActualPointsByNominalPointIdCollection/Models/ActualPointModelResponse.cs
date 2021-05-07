using System;

namespace Faro.MetrologyManager.Ports.Api.Controllers.v1.Point.Responses.GetActualPointsByNominalPointIdCollection.Models
{
    public class ActualPointModelResponse
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public TimeSpan RowVersion { get; set; }
        public Guid NominalPointId { get; set; }
        public string Name { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }
        public decimal DistanceFromNominalPoint { get; set; }
    }
}
