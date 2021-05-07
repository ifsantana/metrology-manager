using System;
using System.Numerics;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetActualPointsCollectionByNominalPointId.Models
{
    public class ActualPointsCollectionByNominalPointIdReturnModel
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public TimeSpan RowVersion { get; set; }
        public Guid NominalPointId { get; set; }
        public NominalPointCollectionByNominalPointIdReturnModel NominalPoint { get; set; }
        public string Name { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }
        public decimal DistanceFromNominalPoint => CalculateDistanceFromNominalPoint();

        private decimal CalculateDistanceFromNominalPoint()
        {
            Vector3 nominal = new Vector3(Decimal.ToSingle(NominalPoint.X), Decimal.ToSingle(NominalPoint.Y), Decimal.ToSingle(NominalPoint.Z));
            Vector3 actual = new Vector3(Decimal.ToSingle(this.X), Decimal.ToSingle(this.Y), Decimal.ToSingle(this.Z));

            return Convert.ToDecimal(Vector3.Distance(actual, nominal));
        }
    }
}
