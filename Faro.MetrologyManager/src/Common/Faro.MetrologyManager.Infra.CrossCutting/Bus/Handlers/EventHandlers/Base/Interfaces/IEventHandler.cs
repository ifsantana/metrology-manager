using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.Base.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Messages.Interfaces;
using MediatR;

namespace Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.EventHandlers.Base.Interfaces
{
    public interface IEventHandler<in TEvent> : IHandler, INotificationHandler<TEvent>
        where TEvent : IEvent
    {
    }
}
