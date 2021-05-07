using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.FailedToAddPoint.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.FailedToAddPoint.Models;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.FailedToAddPoint
{
    public class FailedToAddPointEvent : IFailedToAddPointEvent
    {
        public FailedPoint FailedPoint { get ; set; }
    }
}
