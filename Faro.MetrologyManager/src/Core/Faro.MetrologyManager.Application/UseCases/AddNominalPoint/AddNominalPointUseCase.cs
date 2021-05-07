using Faro.MetrologyManager.Application.UseCases.AddNominalPoint.Interfaces;
using Faro.MetrologyManager.Application.UseCases.AddNominalPoint.Models;
using Faro.MetrologyManager.Application.UseCases.Assets.Base;
using Faro.MetrologyManager.Domain.Entities.Points;
using Faro.MetrologyManager.Domain.Factories.Interfaces;
using Faro.MetrologyManager.Domain.Services.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Adapters.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.FailedToAddPoint;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.PointAdded;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.PointAdded.Models;
using Faro.MetrologyManager.Infra.CrossCutting.UnitOfWork.Interfaces;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Faro.MetrologyManager.Application.UseCases.AddNominalPoint
{
	public class AddNominalPointUseCase : UseCaseBase, IAddNominalPointUseCase
	{
		private readonly IPointService _pointService;
		private readonly IPointFactory _pointFactory;

		public AddNominalPointUseCase(ILogger logger, IBus bus, IUnitOfWork unitOfWork, IAdapter adapter, IPointService pointService, IPointFactory pointFactory) 
			: base(logger, bus, unitOfWork, adapter)
		{
			_pointService = pointService;
			_pointFactory = pointFactory;
		}

		public async Task<(bool, PointAddedEvent)> ExecuteAsync(AddNominalPointUseCaseInput input, CancellationToken cancellationToken)
		{
			var processResult = false;
			var addedPoinEvent = default(PointAddedEvent);

			processResult =  await UnitOfWork.ExecuteWithTransactionAsync(async () =>
				{
					// 1 Step - Register Point
					var addPointEntryResult = RegisterPointEntryStep(input);

					if (!addPointEntryResult.success)
						return false;

					var point = addPointEntryResult.point;

					// 2 Step - Add Asset from Point
					var addOrUpdatedPointResult = await _pointService.AddOrUpdateNewPoint(point, cancellationToken).ConfigureAwait(false);

					if (!addOrUpdatedPointResult.sucess)
					{
                        // Notify Failed
                        _ = await Bus.SendEventAsync(Adapter.Adapt<FailedToAddPointEvent>(input), cancellationToken).ConfigureAwait(false);

                        return false;
					}

					addedPoinEvent = new PointAddedEvent { AddedPoint = Adapter.Adapt<AddedPoint>(addOrUpdatedPointResult.addedPoint) };

					// Notify Success
					if (addOrUpdatedPointResult.isNewPoint)
						_ = await Bus.SendEventAsync(addedPoinEvent, cancellationToken).ConfigureAwait(false);

					return true;
				},	
				cancellationToken
			).ConfigureAwait(false);

			return (processResult, addedPoinEvent);
		}

		#region Step 1

		protected (bool success, Point point) RegisterPointEntryStep(AddNominalPointUseCaseInput input)
		{
			var newAssetEntry = _pointFactory.Create(input.Name);

			newAssetEntry.RegisterNewPointEntry(input.Name, input.X, input.Y, input.Z, input.ExecutionUser);

			return (true, newAssetEntry);
		}

		#endregion
	}
}
