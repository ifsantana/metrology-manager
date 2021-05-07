using Faro.MetrologyManager.Infra.CrossCutting.Adapters.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.EventHandlers.DomainNotifications.Enums;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.EventHandlers.DomainNotifications.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Interfaces;
using Faro.MetrologyManager.Ports.Api.Controllers.v1.Response;
using Faro.MetrologyManager.Ports.Api.Controllers.v1.Response.Enums;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Faro.MetrologyManager.Ports.Api.Controllers.v1.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseControllerV1 : ControllerBase
    {
        protected ILogger Logger { get; }
        protected IBus Bus { get; }
        protected IRaisedDomainNotifications RaisedDomainNotifications { get; }
        protected IAdapter Adapter { get; }

        protected BaseControllerV1(
            ILogger logger,
            IBus bus,
            IRaisedDomainNotifications raisedDomainNotifications,
            IAdapter adapter
        )
        {
            Logger = logger;
            Bus = bus;
            RaisedDomainNotifications = raisedDomainNotifications;
            Adapter = adapter;
        }

        protected IActionResult CreateResponseObject<TData>(TData data)
        {
            var response = new ResponseBase<TData>
            {
                Data = data
            };

            foreach (var domainNotification in RaisedDomainNotifications.AllDomainNotificationEventCollection)
            {
                response.ResponseMessageCollection.Add(new Response.Models.ResponseMessage
                {
                    Code = domainNotification.Code,
                    MessageType = domainNotification.NotificationTypeName,
                    Message = domainNotification.Code
                });
            }

            var actionResult = default(IActionResult);

            if (RaisedDomainNotifications.IsSuccess)
            {
                response.ExecutionResponseStatus = ExecutionStatus.Success;
                actionResult = Ok(response);
            }
            else
            {
                if (RaisedDomainNotifications.ValidationStatus == ValidationStatus.Partial)
                {
                    response.ExecutionResponseStatus = ExecutionStatus.PartialSuccess;
                    actionResult = Ok(response);
                }
                else
                {
                    response.ExecutionResponseStatus = ExecutionStatus.Error;
                    actionResult = UnprocessableEntity(response);
                }
            }

            return actionResult;
        }
    }

}
