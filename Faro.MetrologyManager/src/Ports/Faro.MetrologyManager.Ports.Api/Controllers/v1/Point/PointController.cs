using Faro.MetrologyManager.Infra.CrossCutting.Adapters.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.EventHandlers.DomainNotifications.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.AddActualPoint;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.AddActualPoint.Models;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.AddNominalPoint;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.AddNominalPoint.Models;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.RemoveActualPoint;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.RemoveActualPoint.Models;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.ActualPointAdded;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.PointAdded;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetActualPointsCollectionByNominalPointId;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetActualPointsCollectionByNominalPointId.Models;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsCollection;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsCollection.Models;
using Faro.MetrologyManager.Ports.Api.Controllers.v1.Base;
using Faro.MetrologyManager.Ports.Api.Controllers.v1.NominalPoint.Payloads;
using Faro.MetrologyManager.Ports.Api.Controllers.v1.Point.Payloads;
using Faro.MetrologyManager.Ports.Api.Controllers.v1.Point.Responses;
using Faro.MetrologyManager.Ports.Api.Controllers.v1.Point.Responses.GetActualPointsByNominalPointIdCollection;
using Faro.MetrologyManager.Ports.Api.Controllers.v1.Response;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Faro.MetrologyManager.Ports.Api.Controllers.v1
{
    [ApiController]
	[ApiVersion("1", Deprecated = false)]
	[Route("api/v{version:apiVersion}/points/")]
	[Produces("application/json")]
    public class PointController : BaseControllerV1
    {
        public static string BASE_PATH = "api/v1/";
        public static string POINT_COLLECTION_NAME = "points/";
        public static string NOMINAL_POINT_SUBCOLLECTION_NAME = "nominals/";
        public static string ACTUAL_POINT_SUBCOLLECTION_NAME = "actuals/";

        public PointController(ILogger logger, IBus bus, IRaisedDomainNotifications raisedDomainNotifications, IAdapter adapter) 
			: base(logger, bus, raisedDomainNotifications, adapter)
		{

		}

        [HttpGet("nominals")]
        [ProducesResponseType(typeof(ResponseBase<GetNominalPointsCollectionResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetNominalPointsAsync(CancellationToken cancellationToken)
        {
            var queryResult = await Bus.SendQueryAsync<GetNominalPointsCollectionQuery, GetNominalPointsCollectionQueryReturn>(
                new GetNominalPointsCollectionQuery(),
                cancellationToken
            ).ConfigureAwait(false);
            
            return CreateResponseObject(Adapter.Adapt<GetNominalPointsCollectionResponse>(queryResult));
        }

        [HttpPost("nominals")]
        [ProducesResponseType(typeof(ResponseBase<bool>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddNominalPoint(AddNominalPointPayload payload, CancellationToken cancellationToken)
        {
            var resultCommand = await Bus.SendCommandAsync<AddNominalPointCommand, (bool, PointAddedEvent)>(
                new AddNominalPointCommand()
                {
                    Input = new AddNominalPointCommandInput()
                    {
                        ExecutionUser = payload.ExecutionUser,
                        Name = payload.Name,
                        X = payload.X,
                        Y = payload.Y,
                        Z = payload.Z
                    }
                },
                cancellationToken: cancellationToken
            ).ConfigureAwait(false);
            
            if(resultCommand.Item1 == true)
            {
                var uri = $"{BASE_PATH}{POINT_COLLECTION_NAME}{NOMINAL_POINT_SUBCOLLECTION_NAME}{resultCommand.Item2.AddedPoint.Id}";

                return Created(uri, CreateResponseObject(resultCommand.Item2.AddedPoint));
            }

            return CreateResponseObject(resultCommand);
        }

        [HttpDelete("nominals")]
        public IActionResult DeleteNominalPoint()
        {
            return Ok();
        }

        [HttpPut("nominals")]
        public IActionResult PutNominalPoint()
        {
            return Ok();
        }

        [HttpPatch("nominals")]
        public IActionResult PatchNominalPoint()
        {
            return Ok();
        }

        #region ACTUAL_POINTS

        [HttpGet("actuals")]
        public IActionResult GetAllActualPoints()
        {
            return Ok();
        }

        [HttpGet("nominals/{nominalPointId}/actuals")]
        [ProducesResponseType(typeof(ResponseBase<GetActualPointsByNominalPointIdCollectionResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllActualPointsByNominalPointId([FromRoute] Guid nominalPointId, CancellationToken cancellationToken)
        {
            var queryResult = await Bus.SendQueryAsync<GetActualPointsCollectionByNominalPointIdQuery, GetActualPointsCollectionByNominalPointIdQueryReturn>(
                new GetActualPointsCollectionByNominalPointIdQuery { NominalPointId = nominalPointId },
                cancellationToken
            ).ConfigureAwait(false);

            return CreateResponseObject(Adapter.Adapt<GetActualPointsByNominalPointIdCollectionResponse>(queryResult));
        }

        [HttpPost("nominals/{nominalPointId}/actuals")]
        [ProducesResponseType(typeof(ResponseBase<bool>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddActualPoint(AddActualPointPayload payload, [FromRoute] Guid nominalPointId, CancellationToken cancellationToken)
        {
            var resultCommand = await Bus.SendCommandAsync<AddActualPointCommand, (bool, ActualPointAddedEvent)>(
                new AddActualPointCommand()
                {
                    Input = new AddActualPointCommandInput()
                    {
                        ExecutionUser = payload.ExecutionUser,
                        NominalPointId = nominalPointId,
                        Name = payload.Name,
                        X = payload.X,
                        Y = payload.Y,
                        Z = payload.Z
                    }
                },
                cancellationToken: cancellationToken
            ).ConfigureAwait(false);

            if (resultCommand.Item1 == true)
            {
                var uri = $"{BASE_PATH}{POINT_COLLECTION_NAME}{ACTUAL_POINT_SUBCOLLECTION_NAME}{resultCommand.Item2.AddedActualPoint.Id}";

                return Created(uri, CreateResponseObject(resultCommand.Item2.AddedActualPoint));
            }

            return CreateResponseObject(resultCommand);
        }

        [HttpDelete("actuals")]
        [ProducesResponseType(typeof(ResponseBase<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteActualPoint([FromBody]RemoveActualPointPayload payload, CancellationToken cancellationToken)
        {
            var resultCommand = await Bus.SendCommandAsync<RemoveActualPointCommand, bool>(
               new RemoveActualPointCommand()
               {
                   Input = new RemoveActualPointCommandInput()
                   {
                       Id = payload.Id,
                       ExecutionUser = payload.ExecutionUser
                   }
               },
               cancellationToken: cancellationToken
           ).ConfigureAwait(false);

            return CreateResponseObject(resultCommand);
        }

        [HttpPut]
        public IActionResult PutActualPoint()
        {
            return Ok();
        }

        [HttpPatch]
        public IActionResult PatchActualPoint()
        {
            return Ok();
        }
        #endregion
    }
}
