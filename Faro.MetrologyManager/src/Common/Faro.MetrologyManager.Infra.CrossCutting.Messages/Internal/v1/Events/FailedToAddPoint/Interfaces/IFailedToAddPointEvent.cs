using Faro.MetrologyManager.Infra.CrossCutting.Bus.Messages.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.FailedToAddPoint.Models;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.FailedToAddPoint.Interfaces
{
    public interface IFailedToAddPointEvent : IEvent
    {
        FailedPoint FailedPoint { get; set; }
    }
}
