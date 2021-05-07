
using static Faro.MetrologyManager.Infra.CrossCutting.Bus.Interfaces.IBus;

namespace Faro.MetrologyManager.Infra.CrossCutting.Bus.Interfaces
{
	public interface IEventSendedInterceptor
	{
		EventSendedHandler EventSendedHandler { get; }
	}
}
