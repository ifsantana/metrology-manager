using Faro.MetrologyManager.Infra.CrossCutting.Bus.Events.DomainNotifications;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Events.DomainNotifications.Enums;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.EventHandlers.DomainNotifications.Enums;
using System.Collections.Generic;

namespace Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.EventHandlers.DomainNotifications.Interfaces
{
    public interface IRaisedDomainNotifications
    {
        List<DomainNotificationEvent> DomainNotificationEventCollection { get; }
        IEnumerable<DomainNotificationEvent> AllDomainNotificationEventCollection { get; }
        IEnumerable<DomainNotificationEvent> InfoDomainNotificationEventCollection { get; }
        IEnumerable<DomainNotificationEvent> WarningDomainNotificationEventCollection { get; }
        IEnumerable<DomainNotificationEvent> ErrorDomainNotificationEventCollection { get; }
        bool HasDomainNotificationEvents { get; }
        bool HasInfoDomainNotificationEvents { get; }
        bool HasWarningDomainNotificationEvents { get; }
        bool HasErrorDomainNotificationEvents { get; }
        ValidationStatus ValidationStatus { get; }
        bool IsSuccess { get; }
        void AddErrorValidationMessage(string source, string code);
        void AddInfoValidationMessage(string source, string code);
        void AddValidationMessage(NotificationMessageType messageType, string source, string code);
        void AddWarningValidationMessage(string source, string code);
    }
}
