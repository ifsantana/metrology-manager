using Faro.MetrologyManager.Application.Handlers.Commands.ActualPoint.Interfaces;
using Faro.MetrologyManager.Application.UseCases.AddActualPoint.Interfaces;
using Faro.MetrologyManager.Application.UseCases.AddActualPoint.Models;
using Faro.MetrologyManager.Infra.CrossCutting.Adapters.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.CommandHandlers.Base;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.AddActualPoint;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.ActualPointAdded;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace Faro.MetrologyManager.Application.Handlers.Commands.ActualPoint
{
    public class AddActualPointCommandHandler : CommandHandlerBase<AddActualPointCommand, (bool, ActualPointAddedEvent)>, IAddActualPointCommandHandler
    {
		private readonly IAddActualPointUseCase _addAcutalPointUseCase;

		public AddActualPointCommandHandler(ILogger logger, IBus bus, IAdapter adapter, IAddActualPointUseCase addAcutalPointUseCase) 
            : base(logger, bus, adapter)
		{
			_addAcutalPointUseCase = addAcutalPointUseCase;
		}

        public override async Task<(bool, ActualPointAddedEvent)> Handle(AddActualPointCommand request, CancellationToken cancellationToken)
        {
            return await _addAcutalPointUseCase.ExecuteAsync(Adapter.Adapt<AddActualPointUseCaseInput>(request.Input), cancellationToken).ConfigureAwait(false);
        }
    }
}
