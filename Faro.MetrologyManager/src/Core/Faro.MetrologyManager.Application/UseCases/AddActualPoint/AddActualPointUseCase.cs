using Faro.MetrologyManager.Application.UseCases.AddActualPoint.Interfaces;
using Faro.MetrologyManager.Application.UseCases.AddActualPoint.Models;
using Faro.MetrologyManager.Application.UseCases.Assets.Base;
using Faro.MetrologyManager.Domain.Entities.Points;
using Faro.MetrologyManager.Domain.Factories.Interfaces;
using Faro.MetrologyManager.Domain.Services.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Adapters.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.ActualPointAdded;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.FailedToAddActualPoint;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.PointAdded.Models;
using Faro.MetrologyManager.Infra.CrossCutting.UnitOfWork.Interfaces;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Faro.MetrologyManager.Application.UseCases.AddActualPoint
{
    public class AddActualPointUseCase : UseCaseBase, IAddActualPointUseCase
    {
		private readonly IPointService _pointService;
		private readonly IActualPointFactory _actualPointFactory;

		public AddActualPointUseCase(ILogger logger, IBus bus, IUnitOfWork unitOfWork, IAdapter adapter, IPointService pointService,
			IActualPointFactory actualPointFactory
		) : base(logger, bus, unitOfWork, adapter)
		{
			_pointService = pointService;
			_actualPointFactory = actualPointFactory;
		}

		public async Task<(bool, ActualPointAddedEvent)> ExecuteAsync(AddActualPointUseCaseInput input, CancellationToken cancellationToken)
        {
			var processResult = false;
			var addedPoinEvent = default(ActualPointAddedEvent);

			processResult = await UnitOfWork.ExecuteWithTransactionAsync(async () =>
			{
				// 1 Step - Register Point
				var addPointEntryResult = RegisterActualPointEntryStep(input);

				if (!addPointEntryResult.success)
					return false;

				var point = addPointEntryResult.point;

				// 2 Step - Add Asset from Point
				var addOrUpdatedPointResult = await _pointService.AddOrUpdateNewActualPoint(point, input.NominalPointId, cancellationToken).ConfigureAwait(false);

				if (!addOrUpdatedPointResult.sucess)
				{
					// Notify Failed
					_ = await Bus.SendEventAsync(Adapter.Adapt<FailedToAddActualPointEvent>(input), cancellationToken).ConfigureAwait(false);

					return false;
				}

				addedPoinEvent = new ActualPointAddedEvent { AddedActualPoint = Adapter.Adapt<AddedActualPoint>(addOrUpdatedPointResult.addedActualPoint) };

				// Notify Success
				if (addOrUpdatedPointResult.sucess)
					_ = await Bus.SendEventAsync(addedPoinEvent, cancellationToken).ConfigureAwait(false);

				return true;
			},
				cancellationToken
			).ConfigureAwait(false);

			return (processResult, addedPoinEvent);
		}

		#region Step 1

		protected (bool success, ActualPoint point) RegisterActualPointEntryStep(AddActualPointUseCaseInput input)
		{
			var newAssetEntry = _actualPointFactory.Create(input.Name);

			newAssetEntry.RegisterNewPointEntry(input.Name, input.X, input.Y, input.Z, input.ExecutionUser);

			return (true, newAssetEntry);
		}

		#endregion
	}
}
