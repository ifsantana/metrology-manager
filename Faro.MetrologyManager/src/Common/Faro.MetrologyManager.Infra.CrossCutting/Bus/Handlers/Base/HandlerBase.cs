using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.Base.Interfaces;
using Serilog;

namespace Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.Base
{
    public abstract class HandlerBase : IHandler
    {
        protected ILogger Logger { get; }

        protected HandlerBase(ILogger logger)
        {
            Logger = logger;
        }
    }
}
