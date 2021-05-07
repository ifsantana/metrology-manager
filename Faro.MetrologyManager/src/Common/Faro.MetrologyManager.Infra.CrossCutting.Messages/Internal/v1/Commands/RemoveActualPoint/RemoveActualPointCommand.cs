using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.RemoveActualPoint.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.RemoveActualPoint.Models;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.RemoveActualPoint
{
    public class RemoveActualPointCommand : IRemoveActualPointCommand
    {
        public RemoveActualPointCommandInput Input { get; set; }
    }
}
