using MediatR;

namespace Faro.MetrologyManager.Infra.CrossCutting.Bus.Messages.Interfaces
{
	public interface IEvent : IMessage, INotification
    {
        
    }
}
