using Core.Utilities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Api.Controllers
{
    [ApiController, Route("api")]
    public class BaseApiController : ControllerBase
    {
        private ISender mediator;
        private IConfiguration configuration;
        protected ISender _mediator => mediator ??= HttpContext.RequestServices.GetService<ISender>();

        protected IConfiguration _configuration => configuration ??= HttpContext.RequestServices.GetService<IConfiguration>();


        public Guid UserId
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
