using Faro.MetrologyManager.Application.UseCases.Assets.Base;
using Faro.MetrologyManager.Application.UseCases.RemoveActualPoint.Interfaces;
using Faro.MetrologyManager.Application.UseCases.RemoveActualPoint.Models;
using Faro.MetrologyManager.Infra.CrossCutting.Adapters.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Events.DomainNotifications.Enums;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.ActualPointRemoved;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.ActualPointRemoved.Models;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.FailedToRemoveActualPoint;
using Faro.MetrologyManager.Infra.CrossCutting.UnitOfWork.Interfaces;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace Faro.MetrologyManager.Application.UseCases.RemoveActualPoint
{
    public class RemoveActualPointUseCase : UseCaseBase, IRemoveActualPointUseCase
    {
		public static string EXECUTION_USER_IS_REQUIRED = "EXECUTION_USER_IS_REQUIRED";

		public RemoveActualPointUseCase(ILogger logger, IBus bus, IUnitOfWork unitOfWork, IAdapter adapter)
            : base(logger, bus, unitOfWork, adapter)
        {
        }

        public async Task<bool> ExecuteAsync(RemoveActualPointUseCaseInput input, CancellationToken cancellationToken)
        {
			var processResult = false;

			// Process
			processResult = await UnitOfWork.ExecuteWithTransactionAsync(handleAsync: async () =>
			{
				// 1 Step - Register AssetEntry
				var registerRemoveAssetEntryStepResult = await RegisterRemoveActualPointStepAsync(input: input, cancellationToken).ConfigureAwait(false);

				if (!registerRemoveAssetEntryStepResult)
				{
					// Notify Error
					_ = await Bus.SendEventAsync(Adapter.Adapt<FailedToRemoveActualPointEvent>(input), cancellationToken).ConfigureAwait(false);

					return false;
				};

				// Notify Success
				_ = await Bus.SendEventAsync(new ActualPointRemovedEvent { RemovedActualPoint = Adapter.Adapt<RemovedActualPoint>(input) }, cancellationToken).ConfigureAwait(false);

				return true;
			},
				cancellationToken
			).ConfigureAwait(false);


			return processResult;
		}

		protected async Task<bool> RegisterRemoveActualPointStepAsync(RemoveActualPointUseCaseInput input, CancellationToken cancellationToken)
		{
			// Validate
			if (input.ExecutionUser is null)
			{
				await SendDomainNotificationAsync(NotificationMessageType.Error, 
					nameof(RegisterRemoveActualPointStepAsync), 
					EXECUTION_USER_IS_REQUIRED,
					cancellationToken
				).ConfigureAwait(false);

				return false;
			}

			return true;
		}
	}
}
