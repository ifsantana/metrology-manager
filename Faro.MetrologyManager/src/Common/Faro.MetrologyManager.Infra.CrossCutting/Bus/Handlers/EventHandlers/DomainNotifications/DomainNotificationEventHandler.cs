using Faro.MetrologyManager.Infra.CrossCutting.Bus.Events.DomainNotifications;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.EventHandlers.Base;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.EventHandlers.DomainNotifications.Interfaces;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.EventHandlers.DomainNotifications
{
    public class DomainNotificationEventHandler : EventHandlerBase<DomainNotificationEvent>, IDomainNotificationEventHandler
    {
        private readonly IRaisedDomainNotifications _raisedNotifications;

        public DomainNotificationEventHandler(
            ILogger logger,
            IRaisedDomainNotifications raisedNotifications
        ) : base(logger)
        {
            _raisedNotifications = raisedNotifications;
        }

        public override Task Handle(DomainNotificationEvent notification, CancellationToken cancellationToken)
        {
            _raisedNotifications.AddValidationMessage(
                messageType: notification.NotificationTypeCode,
                source: notification.Source,
                code: notification.Code
            );

            return Task.CompletedTask;
        }
    }
}
