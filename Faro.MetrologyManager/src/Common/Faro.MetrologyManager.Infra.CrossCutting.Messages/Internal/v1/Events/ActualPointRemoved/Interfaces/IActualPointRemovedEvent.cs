using Faro.MetrologyManager.Infra.CrossCutting.Bus.Messages.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.ActualPointRemoved.Models;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.ActualPointRemoved.Interfaces
{
    public interface IActualPointRemovedEvent : IEvent
    {
        RemovedActualPoint RemovedActualPoint { get; set; }
    }
}
