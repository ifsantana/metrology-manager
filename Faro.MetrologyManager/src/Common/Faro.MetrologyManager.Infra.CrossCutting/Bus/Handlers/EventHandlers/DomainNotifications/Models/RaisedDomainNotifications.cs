using Faro.MetrologyManager.Infra.CrossCutting.Bus.Events.DomainNotifications;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Events.DomainNotifications.Enums;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.EventHandlers.DomainNotifications.Enums;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.EventHandlers.DomainNotifications.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.EventHandlers.DomainNotifications.Models
{
    public class RaisedDomainNotifications : IRaisedDomainNotifications
    {
        // Attributes
        public List<DomainNotificationEvent> DomainNotificationEventCollection { get; }

        public RaisedDomainNotifications()
        {
            DomainNotificationEventCollection = new List<DomainNotificationEvent>();
        }

        // Properties
        public IEnumerable<DomainNotificationEvent> AllDomainNotificationEventCollection => DomainNotificationEventCollection.AsEnumerable();
        public IEnumerable<DomainNotificationEvent> InfoDomainNotificationEventCollection => DomainNotificationEventCollection.Where(q => q.NotificationTypeCode == NotificationMessageType.Info);
        public IEnumerable<DomainNotificationEvent> WarningDomainNotificationEventCollection => DomainNotificationEventCollection.Where(q => q.NotificationTypeCode == NotificationMessageType.Warning);
        public IEnumerable<DomainNotificationEvent> ErrorDomainNotificationEventCollection => DomainNotificationEventCollection.Where(q => q.NotificationTypeCode == NotificationMessageType.Error);

        public bool HasDomainNotificationEvents => AllDomainNotificationEventCollection.Any();
        public bool HasInfoDomainNotificationEvents => InfoDomainNotificationEventCollection.Any();
        public bool HasWarningDomainNotificationEvents => WarningDomainNotificationEventCollection.Any();
        public bool HasErrorDomainNotificationEvents => ErrorDomainNotificationEventCollection.Any();

        public ValidationStatus ValidationStatus
        {
            get
            {
                var validationStatus = default(ValidationStatus);

                if (!DomainNotificationEventCollection.Any())
                    validationStatus = ValidationStatus.Success;
                else if (DomainNotificationEventCollection.All(q => q.NotificationTypeCode == NotificationMessageType.Error))
                    validationStatus = ValidationStatus.Error;
                else if (DomainNotificationEventCollection.Any(q => q.NotificationTypeCode == NotificationMessageType.Error))
                    validationStatus = ValidationStatus.Partial;
                else
                    validationStatus = ValidationStatus.Success;

                return validationStatus;
            }
        }
        public bool IsSuccess => ValidationStatus == ValidationStatus.Success;

        // Methods
        public void AddValidationMessage(NotificationMessageType messageType, string source, string code)
        {
            DomainNotificationEventCollection.Add(new DomainNotificationEvent
            (
                notificationType: messageType,
                code: code,
                source: source
            ));
        }
        public void AddInfoValidationMessage(string source, string code)
        {
            AddValidationMessage(NotificationMessageType.Info, source, code);
        }
        public void AddWarningValidationMessage(string source, string code)
        {
            AddValidationMessage(NotificationMessageType.Warning, source, code);
        }
        public void AddErrorValidationMessage(string source, string code)
        {
            AddValidationMessage(NotificationMessageType.Error, source, code);
        }
    }
}
