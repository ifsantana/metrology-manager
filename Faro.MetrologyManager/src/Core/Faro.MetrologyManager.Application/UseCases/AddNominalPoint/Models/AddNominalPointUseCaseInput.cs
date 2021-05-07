using Faro.MetrologyManager.Application.UseCases.Base;

namespace Faro.MetrologyManager.Application.UseCases.AddNominalPoint.Models
{
    public class AddNominalPointUseCaseInput : UseCaseInputBase
    {
        public string Name { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }
    }
}
