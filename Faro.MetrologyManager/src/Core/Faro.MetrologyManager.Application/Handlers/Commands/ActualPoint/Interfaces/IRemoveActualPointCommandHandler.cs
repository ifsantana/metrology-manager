using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.CommandHandlers.Base.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.RemoveActualPoint;

namespace Faro.MetrologyManager.Application.Handlers.Commands.ActualPoint.Interfaces
{
    public interface IRemoveActualPointCommandHandler : ICommandHandler<RemoveActualPointCommand, bool>
    {
    }
}
