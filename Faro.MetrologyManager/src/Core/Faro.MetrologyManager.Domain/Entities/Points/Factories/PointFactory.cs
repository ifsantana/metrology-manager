using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsByIdCollection.Models;
using System;

namespace Faro.MetrologyManager.Domain.Entities.Points.Factories
{
    public class PointFactory : IPointFactory
    {
        public Point Create(GetNominalPointsCollectionByIdQueryReturn parameter)
        {
            var point = Create(parameter.NominalPoint.Name);

            return point;
        }

        public Point Create(string parameter)
        {
            return new Point(parameter);
        }

        public Point Create()
        {
            return default;
        }
    }
}
