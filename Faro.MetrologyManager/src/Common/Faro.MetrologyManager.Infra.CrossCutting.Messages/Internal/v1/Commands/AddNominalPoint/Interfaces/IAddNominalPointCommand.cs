using Faro.MetrologyManager.Infra.CrossCutting.Bus.Messages.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.AddNominalPoint.Models;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.PointAdded;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.AddNominalPoint.Interfaces
{
    public interface IAddNominalPointCommand : ICommand<(bool, PointAddedEvent)>
    {
        AddNominalPointCommandInput Input { get; set; }
    }
}
