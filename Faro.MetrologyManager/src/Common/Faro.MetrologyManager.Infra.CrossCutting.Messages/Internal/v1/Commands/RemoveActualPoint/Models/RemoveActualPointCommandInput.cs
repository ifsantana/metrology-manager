using Faro.MetrologyManager.Infra.CrossCutting.Messages.v1.Commands.Base;
using System;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.RemoveActualPoint.Models
{
    public class RemoveActualPointCommandInput : CommandInputBase
    {
        public Guid Id { get; set; }
    }
}
