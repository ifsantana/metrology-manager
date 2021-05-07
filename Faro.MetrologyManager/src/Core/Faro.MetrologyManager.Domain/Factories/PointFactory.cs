using Faro.MetrologyManager.Domain.Entities.Points;
using Faro.MetrologyManager.Domain.Factories.Interfaces;

namespace Faro.MetrologyManager.Domain.Factories
{
    public class PointFactory : IPointFactory
    {
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
