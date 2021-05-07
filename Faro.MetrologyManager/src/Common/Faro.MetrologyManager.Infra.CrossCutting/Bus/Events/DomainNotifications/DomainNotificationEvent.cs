
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Events.DomainNotifications.Enums;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Messages.Interfaces;

namespace Faro.MetrologyManager.Infra.CrossCutting.Bus.Events.DomainNotifications
{
    public class DomainNotificationEvent : IEvent
    {
        public NotificationMessageType NotificationTypeCode { get; }
        public string NotificationTypeName => NotificationTypeCode.ToString();
        public string Source { get; }
        public string Code { get; }

        public DomainNotificationEvent(NotificationMessageType notificationType, string source, string code)
        {
            NotificationTypeCode = notificationType;
            Source = source;
            Code = code;
        }
    }
}
