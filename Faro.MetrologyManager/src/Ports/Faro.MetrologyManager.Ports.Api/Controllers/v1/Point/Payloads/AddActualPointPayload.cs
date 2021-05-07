using Faro.MetrologyManager.Ports.Api.Controllers.v1.Payloads.Base;

namespace Faro.MetrologyManager.Ports.Api.Controllers.v1.Point.Payloads
{
    public class AddActualPointPayload : PayloadBase
    {
        public string Name { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }
        public decimal DistanceFromNominalPoint { get; set; }
    }
}
