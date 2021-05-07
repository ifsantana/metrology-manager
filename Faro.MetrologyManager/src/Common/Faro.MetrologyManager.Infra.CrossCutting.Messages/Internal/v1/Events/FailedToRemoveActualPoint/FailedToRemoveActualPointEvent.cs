using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.FailedToRemoveActualPoint.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.FailedToRemoveActualPoint.Models;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.FailedToRemoveActualPoint
{
    public class FailedToRemoveActualPointEvent : IFailedToRemoveActualPointEvent
    {
        public FailToRemoveActualPoint FailToRemoveActualPoint { get; set; }
    }
}
