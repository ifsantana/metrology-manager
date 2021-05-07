using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.PointAdded.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.PointAdded.Models;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.PointAdded
{
    public class PointAddedEvent : IPointAddedEvent
    {
        public AddedPoint AddedPoint { get; set; }
    }
}
