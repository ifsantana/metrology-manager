using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.Base.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Messages.Interfaces;
using MediatR;

namespace Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.CommandHandlers.Base.Interfaces
{
    public interface ICommandHandler<TCommand, TResponse> : IHandler, IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
    }
}
