using MediatR;

namespace Faro.MetrologyManager.Infra.CrossCutting.Bus.Messages.Interfaces
{
    public interface ICommand<out TResponse> : IMessage, IRequest<TResponse>
    {
    }
}
