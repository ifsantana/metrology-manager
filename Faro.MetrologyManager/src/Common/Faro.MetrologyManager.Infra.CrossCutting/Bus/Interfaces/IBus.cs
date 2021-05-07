using Faro.MetrologyManager.Infra.CrossCutting.Bus.Messages.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Faro.MetrologyManager.Infra.CrossCutting.Bus.Interfaces
{
    public interface IBus
    {
        public delegate Task EventSendedHandler(IEvent @event, CancellationToken cancellationToken);

        Task<TResponse> SendCommandAsync<TCommand, TResponse>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand<TResponse>;
        Task<bool> SendEventAsync<TEvent>(TEvent @event, CancellationToken cancellationToken) where TEvent : IEvent;
        Task<TResponse> SendQueryAsync<TQuery, TResponse>(TQuery query, CancellationToken cancellationToken) where TQuery : IQuery<TResponse>;
    }
}
