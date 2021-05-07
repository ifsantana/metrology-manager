using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsCollectionById.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsByIdCollection.Models
{
    public class NominalPointsCollectionByIdQueryReturnModel
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public TimeSpan RowVersion { get; set; }
        public string Name { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }

        public List<ActualPointQueryReturnModel> ActualPointsCollection { get; set; }
        public Vector3 AveragePointFromActualPoints => CalculateAverageFromActualPoints();

        private Vector3 CalculateAverageFromActualPoints()
        {
            Vector3 average = Vector3.Zero;

            Vector3[] vectors = this.ActualPointsCollection.Select(a => new Vector3(
                Decimal.ToSingle(a.X),
                Decimal.ToSingle(a.Y),
                Decimal.ToSingle(a.Z)
            )).ToArray();

            foreach (var vector in vectors)
                average += vector;

            return new Vector3(average.X / vectors.Length, average.Y / vectors.Length, average.Z / vectors.Length);
        }
    }
}
