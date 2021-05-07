using Faro.MetrologyManager.Domain.Entities.Points;
using System;

namespace Faro.MetrologyManager.Domain.Factories.Interfaces
{
    class ActualPointFactory : IActualPointFactory
    {
        public ActualPoint Create(string parameter)
        {
            return new ActualPoint(parameter);
        }

        public ActualPoint Create()
        {
            throw new NotImplementedException();
        }
    }
}
