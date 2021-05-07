using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.AddActualPoint.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.AddActualPoint.Models;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.AddActualPoint
{
    public class AddActualPointCommand : IAddActualPointCommand
    {
        public AddActualPointCommandInput Input { get; set; }
    }
}
