using Faro.MetrologyManager.Domain.Entities.Base;

namespace Faro.MetrologyManager.Domain.Services.Base.Interfaces
{
    public interface IService<TAggregationRoot>
        where TAggregationRoot : IAggregationRoot
    {
    }
}
