using Faro.MetrologyManager.Domain.Entities.Base;
using Faro.MetrologyManager.Infra.CrossCutting.ExtensionMethods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Faro.MetrologyManager.Infra.CrossCutting.ExtensionMethods;

namespace Faro.MetrologyManager.Domain.Entities.Points
{
    public class Point : BaseEntity, IAggregationRoot
    {
        public string Name { get; protected set; }
        public decimal X { get; protected set; }
        public decimal Y { get; protected set; }
        public decimal Z { get; protected set; }
        public List<ActualPoint> ActualPointsCollection { get; protected set; }
        public SerializedVector3 AveragePointFromActualPoints => CalculateAverageFromActualPoints();

        public Point(string name)
        {
            Name = name;
            ActualPointsCollection = new List<ActualPoint>();
        }

        protected void SetInfo(string name, decimal x, decimal y, decimal z)
        {
            Name = name;
            X = x;
            Y = y;
            Z = z;
        }

        public virtual void RegisterNewPointEntry(
            string name,
            decimal x,
            decimal y,
            decimal z,
            string createdBy
        )
        {
            GenerateNewId();
            GenerateNewRowVersion();
            SetCreationInfo(createdBy, DateTime.UtcNow);
            SetInfo(name, x, y, z);
        }

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
