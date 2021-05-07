using Faro.MetrologyManager.Domain.Entities.Base;
using System;
using System.Numerics;

namespace Faro.MetrologyManager.Domain.Entities.Points
{
    public class ActualPoint : BaseEntity
    {
        public string Name { get; protected set; }
        public decimal X { get; protected set; }
        public decimal Y { get; protected set; }
        public decimal Z { get; protected set; }
        public decimal DistanceFromNominalPoint => CalculateDistanceFromNominalPoint();

        public Point NominalPoint { get; protected set; }

        public ActualPoint(string name)
        {
            Name = name;
        }

        private decimal CalculateDistanceFromNominalPoint()
        {
            Vector3 nominal = new Vector3(Decimal.ToSingle(NominalPoint.X), Decimal.ToSingle(NominalPoint.Y), Decimal.ToSingle(NominalPoint.Z));
            Vector3 actual = new Vector3(Decimal.ToSingle(this.X), Decimal.ToSingle(this.Y), Decimal.ToSingle(this.Z));

            return Convert.ToDecimal(Vector3.Distance(actual, nominal));
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

        public void SetNominalPoint(Point nominal)
        {
            NominalPoint = nominal;
        }
    }
}
