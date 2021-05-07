using Faro.MetrologyManager.Infra.CrossCutting.Bus.Messages.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.PointAdded.Models;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.ActualPointAdded.Interfaces
{
    interface IActualPointAddedEvent : IEvent
    {
        AddedActualPoint AddedActualPoint { get; set; }
    }
}
