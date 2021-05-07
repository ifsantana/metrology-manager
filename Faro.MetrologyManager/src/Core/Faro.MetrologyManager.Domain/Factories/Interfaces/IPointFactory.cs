using Faro.MetrologyManager.Domain.Entities.Points;
using Faro.MetrologyManager.Infra.CrossCutting.Factories.Interfaces;

namespace Faro.MetrologyManager.Domain.Factories.Interfaces
{
    public interface IPointFactory : IFactoryWithParameter<Point,  string>
    {
    }
}
