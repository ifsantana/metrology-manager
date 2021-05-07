using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.CommandHandlers.Base.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.AddNominalPoint;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.PointAdded;

namespace Faro.MetrologyManager.Application.Handlers.Commands.NominalPoint.Interfaces
{
    public interface IAddNominalPointCommandHandler : ICommandHandler<AddNominalPointCommand, (bool, PointAddedEvent)>
    {
    }
}
