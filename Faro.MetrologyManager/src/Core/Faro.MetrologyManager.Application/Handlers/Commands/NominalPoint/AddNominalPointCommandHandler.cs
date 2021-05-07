using Faro.MetrologyManager.Application.Handlers.Commands.NominalPoint.Interfaces;
using Faro.MetrologyManager.Application.UseCases.AddNominalPoint.Interfaces;
using Faro.MetrologyManager.Application.UseCases.AddNominalPoint.Models;
using Faro.MetrologyManager.Infra.CrossCutting.Adapters.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.CommandHandlers.Base;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.AddNominalPoint;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.PointAdded;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace Faro.MetrologyManager.Application.Handlers.Commands.NominalPoint
{
    public class AddNominalPointCommandHandler : CommandHandlerBase<AddNominalPointCommand, (bool, PointAddedEvent)>, IAddNominalPointCommandHandler
    {
        private readonly IAddNominalPointUseCase _addNominalUseCase;

		public AddNominalPointCommandHandler(ILogger logger, IBus bus, IAdapter adapter, IAddNominalPointUseCase addNominalUseCase
        ) : base(logger, bus, adapter)
		{
			_addNominalUseCase = addNominalUseCase;
		}

		public override async Task<(bool, PointAddedEvent)> Handle(AddNominalPointCommand request, CancellationToken cancellationToken)
        {
            return await _addNominalUseCase.ExecuteAsync(Adapter.Adapt<AddNominalPointUseCaseInput>(request.Input), cancellationToken).ConfigureAwait(false);
        }
    }
}
