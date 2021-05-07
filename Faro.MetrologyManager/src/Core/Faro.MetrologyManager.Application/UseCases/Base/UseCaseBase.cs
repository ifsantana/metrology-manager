using System.Threading;
using System.Threading.Tasks;
using Faro.MetrologyManager.Infra.CrossCutting.Adapters.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Events.DomainNotifications;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Events.DomainNotifications.Enums;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.UnitOfWork.Interfaces;
using Serilog;

namespace Faro.MetrologyManager.Application.UseCases.Assets.Base
{
	public abstract class UseCaseBase
	{
		protected ILogger Logger { get; }
		protected IBus Bus { get; }
		protected IUnitOfWork UnitOfWork { get; }
		protected IAdapter Adapter { get; }

		protected UseCaseBase(ILogger logger, IBus bus, IUnitOfWork unitOfWork, IAdapter adapter)
		{
			Logger = logger;
			Bus = bus;
			UnitOfWork = unitOfWork;
			Adapter = adapter;
		}

		protected async Task SendDomainNotificationAsync(NotificationMessageType notificationMessageType, string source, string code, CancellationToken cancellationToken)
		{
			await Bus.SendEventAsync(
				new DomainNotificationEvent(
					notificationMessageType,
					source,
					code
				),
				cancellationToken
			).ConfigureAwait(false);
		}
	}
}
