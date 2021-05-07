using Faro.MetrologyManager.Domain.Entities.Points;
using Faro.MetrologyManager.Infra.CrossCutting.Factories.Interfaces;

namespace Faro.MetrologyManager.Domain.Factories.Interfaces
{
    public interface IActualPointFactory : IFactoryWithParameter<ActualPoint, string>
    {
    }
}
