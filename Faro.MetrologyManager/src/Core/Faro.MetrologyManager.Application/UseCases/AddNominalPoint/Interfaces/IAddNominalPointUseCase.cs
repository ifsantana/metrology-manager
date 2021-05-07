using Faro.MetrologyManager.Application.UseCases.AddNominalPoint.Models;
using Faro.MetrologyManager.Application.UseCases.Assets.Base.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.PointAdded;
using System.Threading;
using System.Threading.Tasks;

namespace Faro.MetrologyManager.Application.UseCases.AddNominalPoint.Interfaces
{
    public interface IAddNominalPointUseCase : IUseCase
    {
        Task<(bool, PointAddedEvent)> ExecuteAsync(AddNominalPointUseCaseInput input, CancellationToken cancellationToken);
    }
}
