using Faro.MetrologyManager.Application.Handlers.Commands.ActualPoint.Interfaces;
using Faro.MetrologyManager.Application.UseCases.RemoveActualPoint.Interfaces;
using Faro.MetrologyManager.Application.UseCases.RemoveActualPoint.Models;
using Faro.MetrologyManager.Infra.CrossCutting.Adapters.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.CommandHandlers.Base;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.RemoveActualPoint;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace Faro.MetrologyManager.Application.Handlers.Commands.ActualPoint
{
    public class RemoveActualPointCommandHandler : CommandHandlerBase<RemoveActualPointCommand, bool>, IRemoveActualPointCommandHandler
    {

        private readonly IRemoveActualPointUseCase _removeActualPointUseCase;

        public RemoveActualPointCommandHandler(ILogger logger, IBus bus, IAdapter adapter, IRemoveActualPointUseCase removeActualPointUseCase) 
            : base(logger, bus, adapter)
		{
            _removeActualPointUseCase = removeActualPointUseCase;
		}

        public override async Task<bool> Handle(RemoveActualPointCommand request, CancellationToken cancellationToken)
        {
            var removeActualPointUseCaseInput = Adapter.Adapt<RemoveActualPointUseCaseInput>(request.Input);

            return await _removeActualPointUseCase.ExecuteAsync(input: removeActualPointUseCaseInput, cancellationToken).ConfigureAwait(false);
        }
    }
}
