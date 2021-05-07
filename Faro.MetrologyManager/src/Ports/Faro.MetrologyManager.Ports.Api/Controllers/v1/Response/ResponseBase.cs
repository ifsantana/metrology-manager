using Faro.MetrologyManager.Ports.Api.Controllers.v1.Response.Enums;
using Faro.MetrologyManager.Ports.Api.Controllers.v1.Response.Models;
using System.Collections.Generic;

namespace Faro.MetrologyManager.Ports.Api.Controllers.v1.Response
{
    public class ResponseBase<T>
    {
        public ExecutionStatus ExecutionResponseStatus { get; set; }
        public string ExecutionResponseStatusDescription => ExecutionResponseStatus.ToString();
        public T Data { get; set; }
        public List<ResponseMessage> ResponseMessageCollection { get; set; }

        public ResponseBase()
        {
            ResponseMessageCollection = new List<ResponseMessage>();
        }
    }
}
