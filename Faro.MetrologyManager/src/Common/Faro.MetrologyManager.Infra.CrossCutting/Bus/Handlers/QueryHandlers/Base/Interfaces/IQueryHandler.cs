using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.Base.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Messages.Interfaces;
using MediatR;

namespace Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.QueryHandlers.Base.Interfaces
{
    public interface IQueryHandler<TQuery, TResponse> : IHandler, IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
    }
}
