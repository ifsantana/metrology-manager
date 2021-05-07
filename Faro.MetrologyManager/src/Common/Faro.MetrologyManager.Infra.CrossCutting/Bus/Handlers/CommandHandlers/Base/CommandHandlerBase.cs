using Faro.MetrologyManager.Infra.CrossCutting.Adapters.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Events.DomainNotifications;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Events.DomainNotifications.Enums;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.Base;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.CommandHandlers.Base.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Messages.Interfaces;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.CommandHandlers.Base
{
    public abstract class CommandHandlerBase<TCommand, TResponse> : HandlerBase, ICommandHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
	    protected IBus Bus { get; }
        protected IAdapter Adapter { get; }

	    protected CommandHandlerBase(ILogger logger, IBus bus, IAdapter adapter) 
            : base(logger)
        {
            Bus = bus;
            Adapter = adapter;
        }

        public abstract Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken);

        protected async Task SendDomainNotificationAsync(NotificationMessageType notificationMessageType, string source, string code, CancellationToken cancellationToken)
        {
            await Bus.SendEventAsync(
                new DomainNotificationEvent(
                    notificationMessageType,
                    source,
                    code
                ),
                cancellationToken
            ).ConfigureAwait(false);
        }
    }
}
