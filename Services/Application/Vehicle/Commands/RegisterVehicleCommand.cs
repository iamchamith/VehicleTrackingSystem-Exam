using MediatR;
using System.ComponentModel.DataAnnotations;
namespace Services.Application.Vehicle.Commands
{
    public class RegisterVehicleCommand : IRequest<string>
    {
        [StringLength(10), Required]
        public string VehicleId { get; set; }
    }
}
