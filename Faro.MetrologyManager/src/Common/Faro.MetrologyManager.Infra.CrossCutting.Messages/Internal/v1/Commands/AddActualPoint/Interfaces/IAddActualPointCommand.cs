using Faro.MetrologyManager.Infra.CrossCutting.Bus.Messages.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.AddActualPoint.Models;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.ActualPointAdded;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.AddActualPoint.Interfaces
{
    public interface IAddActualPointCommand : ICommand<(bool, ActualPointAddedEvent)>
    {
        AddActualPointCommandInput Input { get; set; }
    }
}
