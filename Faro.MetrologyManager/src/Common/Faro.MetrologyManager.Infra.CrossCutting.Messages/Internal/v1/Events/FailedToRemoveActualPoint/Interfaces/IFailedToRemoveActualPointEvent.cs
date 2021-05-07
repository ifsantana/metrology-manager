using Faro.MetrologyManager.Infra.CrossCutting.Bus.Messages.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.FailedToRemoveActualPoint.Models;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.FailedToRemoveActualPoint.Interfaces
{
    public interface IFailedToRemoveActualPointEvent : IEvent
    {
        FailToRemoveActualPoint FailToRemoveActualPoint { get; set; }
    }
}
