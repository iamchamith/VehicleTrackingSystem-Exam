using Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using Services.Application.Tracking.Commands;
using Services.Application.Tracking.Queries;
using System;
using System.Threading.Tasks;


namespace Api.Controllers
{
    [Route("vehicles/trakings")]
    public class TrackingApiController : BaseApiController
    {
        [HttpPost("trackings"), ModelValidation]
        public async Task<IActionResult> AddTrackings([FromBody] AddTrackInfoCommand request)
        {
            try
            {
                request.AddVehicleId(UserId);
                var result = await _mediator.Send(request);
                return Ok();
            }
            catch (Exception e)
            {
                return ExceptionMapper(e);
            }
        }

        [HttpGet("{vehicleid}/trakings/current")]
        public async Task<IActionResult> GetCurrentLocation(string vehicleid)
        {
            try
            {
                var response = await _mediator.Send(new GetCurrentLocationByVehicleIdQuery(vehicleid.ToGuid()));
                return Ok(response);
            }
            catch (Exception e)
            {
                return ExceptionMapper(e);
            }
        }
        [HttpGet("{vehicleid}/trakings")]
        public async Task<IActionResult> GetLocationsByPeriod(string vehicleid, [FromQuery] DateTime fromDateTime, [FromQuery] DateTime toDateTime)
        {
            try
            {
                var result = await _mediator.Send(new GetLocationQuery(vehicleid.ToGuid(), fromDateTime, toDateTime));
                return Ok(result);
            }
            catch (Exception e)
            {
                return ExceptionMapper(e);
            }
        }
    }
}
