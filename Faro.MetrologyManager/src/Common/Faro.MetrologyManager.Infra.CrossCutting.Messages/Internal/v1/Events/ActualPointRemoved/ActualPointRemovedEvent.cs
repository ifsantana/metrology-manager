using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.ActualPointRemoved.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.ActualPointRemoved.Models;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.ActualPointRemoved
{
    public class ActualPointRemovedEvent : IActualPointRemovedEvent
    {
        public RemovedActualPoint RemovedActualPoint { get; set; }
    }
}
