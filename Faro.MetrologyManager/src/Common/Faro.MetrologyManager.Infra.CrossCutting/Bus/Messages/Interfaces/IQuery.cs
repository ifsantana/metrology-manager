using MediatR;

namespace Faro.MetrologyManager.Infra.CrossCutting.Bus.Messages.Interfaces
{
    public interface IQuery<out TReturn> : IMessage, IRequest<TReturn>
    {

    }
}
