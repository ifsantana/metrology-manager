using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.Base;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.QueryHandlers.Base.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Messages.Interfaces;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace Clear.Safekeeping.Infra.CrossCutting.Bus.Handlers.QueryHandlers.Base
{
    public abstract class QueryHandlerBase<TQuery, TResponse> : HandlerBase, IQueryHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
        protected QueryHandlerBase(ILogger logger) 
            : base(logger)
        {
        }

        public abstract Task<TResponse> Handle(TQuery request, CancellationToken cancellationToken);
    }
}
