
using Faro.MetrologyManager.Application.UseCases.Base;
using System;

namespace Faro.MetrologyManager.Application.UseCases.AddActualPoint.Models
{
    public class AddActualPointUseCaseInput : UseCaseInputBase
    {
        public string Name { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }
        public Guid NominalPointId { get; set; }
    }
}
