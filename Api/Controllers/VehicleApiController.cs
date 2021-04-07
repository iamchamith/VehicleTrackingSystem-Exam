using Microsoft.AspNetCore.Mvc;
using Services.Application.Vehicle.Commands;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("vehicles")]
    public class VehicleApiController : BaseApiController
    {
        public VehicleApiController()
        {

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterVehicleCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return ExceptionMapper(e);
            }
        }
        [HttpPost("authenticate"),]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateVehicleCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(Helper.GenerateJSONWebToken(result, _configuration["AppSettings:JwtKey"]));
            }
            catch (Exception e)
            {
                return ExceptionMapper(e);
            }
        }
    }
}
