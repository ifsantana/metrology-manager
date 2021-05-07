using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.FailedToAddActualPoint.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.FailedToAddActualPoint.Models;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.FailedToAddActualPoint
{
    public class FailedToAddActualPointEvent : IFailedToAddActualPointEvent
    {
        public FailedActualPoint FailedActualPoint { get; set; }
    }
}
