using Faro.MetrologyManager.Application.UseCases.Base;
using System;

namespace Faro.MetrologyManager.Application.UseCases.RemoveActualPoint.Models
{
    public class RemoveActualPointUseCaseInput : UseCaseInputBase
    {
        public Guid Id { get; set; }
    }
}
