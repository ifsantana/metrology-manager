using Faro.MetrologyManager.Infra.CrossCutting.Bus.Messages.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.RemoveActualPoint.Models;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.RemoveActualPoint.Interfaces
{
    public interface IRemoveActualPointCommand : ICommand<bool>
    {
        RemoveActualPointCommandInput Input { get; set; }
    }
}
