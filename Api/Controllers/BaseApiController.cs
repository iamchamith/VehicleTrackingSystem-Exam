using Core.Utilities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Api.Controllers
{
    [ApiController, Route("api")]
    public class BaseApiController : ControllerBase
    {
        private ISender mediator;
        private IConfiguration configuration;
        private ILogger logger;
        protected ISender _mediator => mediator ??= HttpContext.RequestServices.GetService<ISender>();
        protected ILogger _logger => logger ??= HttpContext.RequestServices.GetService<ILogger>();
        protected IConfiguration _configuration => configuration ??= HttpContext.RequestServices.GetService<IConfiguration>();

        protected IActionResult ExceptionMapper(Exception ex)
        {

            if (ex is InvalidDataException)
                return BadRequest(ex.Message);
            else if (ex is UnauthorizedAccessException)
                return StatusCode(401);
            else
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }

        protected Guid UserId
        {
            get
            {
                try
                {
                    var authHeader = HttpContext.Request.Headers["Authorization"].ToString();
                    if (string.IsNullOrEmpty(authHeader))
                        throw new UnauthorizedAccessException();
                    var response = Helper.GetClaimByName(authHeader.Replace("Bearer ", ""), "id");
                    if (string.IsNullOrEmpty(response))
                        throw new UnauthorizedAccessException();
                    return response.ToGuid();
                }
                catch (Exception)
                {
                    throw new UnauthorizedAccessException();
                }
            }
        }
    }
}
