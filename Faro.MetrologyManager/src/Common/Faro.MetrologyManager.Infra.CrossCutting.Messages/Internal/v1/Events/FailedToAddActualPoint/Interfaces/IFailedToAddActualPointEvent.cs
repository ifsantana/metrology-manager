using Faro.MetrologyManager.Infra.CrossCutting.Bus.Messages.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.FailedToAddActualPoint.Models;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.FailedToAddActualPoint.Interfaces
{
    public interface IFailedToAddActualPointEvent : IEvent
    {
        FailedActualPoint FailedActualPoint { get; set; }
    }
}
