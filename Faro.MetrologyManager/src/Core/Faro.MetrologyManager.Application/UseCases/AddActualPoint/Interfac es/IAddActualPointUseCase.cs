using Faro.MetrologyManager.Application.UseCases.AddActualPoint.Models;
using Faro.MetrologyManager.Application.UseCases.Assets.Base.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.ActualPointAdded;
using System.Threading;
using System.Threading.Tasks;

namespace Faro.MetrologyManager.Application.UseCases.AddActualPoint.Interfaces
{
    public interface IAddActualPointUseCase : IUseCase
    {
        Task<(bool, ActualPointAddedEvent)> ExecuteAsync(AddActualPointUseCaseInput input, CancellationToken cancellationToken);
    }
}
