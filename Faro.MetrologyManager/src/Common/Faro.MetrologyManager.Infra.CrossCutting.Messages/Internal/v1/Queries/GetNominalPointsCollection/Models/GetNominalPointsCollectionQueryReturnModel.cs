using Faro.MetrologyManager.Infra.CrossCutting.ExtensionMethods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Faro.MetrologyManager.Infra.CrossCutting.ExtensionMethods;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsCollection.Models
{
    public class GetNominalPointsCollectionQueryReturnModel
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
        public List<GetNominalPointsByIdActualPointsQueryReturnModel> ActualPointsCollection { get; set; }
        public SerializedVector3 AveragePointFromActualPoints => CalculateAverageFromActualPoints();
        private SerializedVector3 CalculateAverageFromActualPoints()
        {
            Vector3 average = Vector3.Zero;

            if (ActualPointsCollection.Count == 0)
                return average.FromVector3();

            Vector3[] vectors = this.ActualPointsCollection.Select(a => new Vector3(
                Decimal.ToSingle(a.X),
                Decimal.ToSingle(a.Y),
                Decimal.ToSingle(a.Z)
            )).ToArray();

            foreach (var vector in vectors)
                average += vector;

            return new Vector3(average.X / vectors.Length, average.Y / vectors.Length, average.Z / vectors.Length).FromVector3();
        }
    }
}
