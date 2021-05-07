using Faro.MetrologyManager.Infra.CrossCutting.Messages.v1.Commands.Base;
using System;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.AddActualPoint.Models
{
    public class AddActualPointCommandInput : CommandInputBase
    {
        public Guid NominalPointId { get; set; }
        public string Name { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }
    }
}
