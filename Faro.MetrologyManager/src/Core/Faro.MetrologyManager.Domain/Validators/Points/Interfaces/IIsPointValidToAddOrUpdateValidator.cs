using Faro.MetrologyManager.Domain.Entities.Points;
using Faro.MetrologyManager.Infra.CrossCutting.Validators.Base.Interfaces;

namespace Faro.MetrologyManager.Domain.Validators.Points.Interfaces
{
    public interface IIsPointValidToAddOrUpdateValidator : IValidator<Point>
    {

    }
}
