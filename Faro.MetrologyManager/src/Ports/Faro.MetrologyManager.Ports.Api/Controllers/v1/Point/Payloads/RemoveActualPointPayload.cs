using Faro.MetrologyManager.Ports.Api.Controllers.v1.Payloads.Base;
using System;

namespace Faro.MetrologyManager.Ports.Api.Controllers.v1.Point.Payloads
{
    public class RemoveActualPointPayload : PayloadBase
    {
        public Guid Id { get; set; }
    }
}
