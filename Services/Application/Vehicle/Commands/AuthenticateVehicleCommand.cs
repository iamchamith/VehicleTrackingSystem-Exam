using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
namespace Services.Application.Vehicle.Commands
{
    public class AuthenticateVehicleCommand : IRequest<Guid>
    {
        [StringLength(10), Required]
        public string VehicleId { get; set; }
        [StringLength(50), Required]
        public string Password { get; set; }
    }
}
