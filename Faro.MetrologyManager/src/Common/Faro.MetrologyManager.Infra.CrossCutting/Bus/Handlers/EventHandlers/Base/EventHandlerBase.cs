using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.Base;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.EventHandlers.Base.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Messages.Interfaces;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.EventHandlers.Base
{
    public abstract class EventHandlerBase<TEvent> : HandlerBase, IEventHandler<TEvent>
        where TEvent : IEvent
    {
        protected EventHandlerBase(ILogger logger) : base(logger)
        {
        }

        public abstract Task Handle(TEvent notification, CancellationToken cancellationToken);
    }
}
