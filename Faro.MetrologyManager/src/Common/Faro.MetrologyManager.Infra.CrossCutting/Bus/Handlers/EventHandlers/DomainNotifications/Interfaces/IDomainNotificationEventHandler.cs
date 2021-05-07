using Faro.MetrologyManager.Infra.CrossCutting.Bus.Events.DomainNotifications;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.EventHandlers.Base.Interfaces;

namespace Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.EventHandlers.DomainNotifications.Interfaces
{
    public interface IDomainNotificationEventHandler : IEventHandler<DomainNotificationEvent>
    {

    }
}
