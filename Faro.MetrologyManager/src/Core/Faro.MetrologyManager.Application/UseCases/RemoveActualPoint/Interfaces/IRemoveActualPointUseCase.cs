using Faro.MetrologyManager.Application.UseCases.Assets.Base.Interfaces;
using Faro.MetrologyManager.Application.UseCases.RemoveActualPoint.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Faro.MetrologyManager.Application.UseCases.RemoveActualPoint.Interfaces
{
    public interface IRemoveActualPointUseCase : IUseCase
    {
        Task<bool> ExecuteAsync(RemoveActualPointUseCaseInput input, CancellationToken cancellationToken);
    }
}
