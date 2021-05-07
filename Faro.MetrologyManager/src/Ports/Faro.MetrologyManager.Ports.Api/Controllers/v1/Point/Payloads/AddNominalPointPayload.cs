using Faro.MetrologyManager.Ports.Api.Controllers.v1.Payloads.Base;

namespace Faro.MetrologyManager.Ports.Api.Controllers.v1.NominalPoint.Payloads
{
    public class AddNominalPointPayload : PayloadBase
    {
        public string Name { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }
    }
}
