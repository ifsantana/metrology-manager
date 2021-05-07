using Faro.MetrologyManager.Infra.CrossCutting.Adapters.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Events.DomainNotifications;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Events.DomainNotifications.Enums;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Serilog;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Faro.MetrologyManager.Domain.Services.Base
{
    public abstract class ServiceBase
	{
		protected ILogger Logger { get; }
		protected IBus Bus { get; }
		protected IAdapter Adapter { get; }

		protected ServiceBase(
			ILogger logger,
			IBus bus,
			IAdapter adapter
		)
		{
			Logger = logger;
			Bus = bus;
			Adapter = adapter;
		}

		private static NotificationMessageType GetNotificationMessageType(Severity severity)
		{
			return severity switch
			{
				Severity.Error => NotificationMessageType.Error,
				Severity.Warning => NotificationMessageType.Warning,
				Severity.Info => NotificationMessageType.Info,
				_ => NotificationMessageType.Info
			};
		}

		protected async Task<bool> CheckValidationResultAndSendDomainNotificationsAsync(string source, ValidationResult[] validationResultArray, CancellationToken cancellationToken)
		{
			var isValid = !validationResultArray.Any(
				validationResult => validationResult.Errors.Any(
					validationFailure => validationFailure.Severity == Severity.Error
				)
			);

			foreach (var validationResult in validationResultArray)
				foreach (var validationFailure in validationResult.Errors)
					await Bus.SendEventAsync(
						new DomainNotificationEvent(
							notificationType: GetNotificationMessageType(validationFailure.Severity),
							source: source,
							code: validationFailure.ErrorMessage
						),
						cancellationToken
					).ConfigureAwait(false);

			return isValid;
		}

		protected async Task<bool> CheckObjectIsNullAndSendDomainNotificationsAsync<T>(T @object, CancellationToken cancellationToken, [CallerMemberName] string source = null)
		{

			if (@object is null)
			{
				await Bus.SendEventAsync(
					new DomainNotificationEvent(
						notificationType: NotificationMessageType.Error,
						source: source,
						code: $"Object cannot be null [{typeof(T).Name.ToUpper()}​​​​]"
					),
					cancellationToken
				).ConfigureAwait(false);

				return false;

			}
			return true;
		}
	}
}
