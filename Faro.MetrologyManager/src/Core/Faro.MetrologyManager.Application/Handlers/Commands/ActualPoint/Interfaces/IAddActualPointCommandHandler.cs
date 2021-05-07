
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.CommandHandlers.Base.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.AddActualPoint;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.ActualPointAdded;

namespace Faro.MetrologyManager.Application.Handlers.Commands.ActualPoint.Interfaces
{
    public interface IAddActualPointCommandHandler : ICommandHandler<AddActualPointCommand, (bool, ActualPointAddedEvent)>
    {
    }
}
