using Faro.MetrologyManager.Infra.CrossCutting.Messages.v1.Commands.Base;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.AddNominalPoint.Models
{
    public class AddNominalPointCommandInput : CommandInputBase
    {
        public string Name { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }
    }
}
