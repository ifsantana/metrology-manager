using Faro.MetrologyManager.Domain.Entities.Points;
using FluentValidation;

namespace Faro.MetrologyManager.Domain.Validators.Points.Interfaces
{
    public interface IIsActualPointValidToAddOrUpdateValidator : IValidator<ActualPoint>
    {
    }
}
