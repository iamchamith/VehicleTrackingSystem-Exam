using Core.Utilities;
using MediatR;
using Services.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Services.Application.Vehicle.Commands
{
    public class AuthenticateVehicleCommandHandler : BaseHandler, IRequestHandler<AuthenticateVehicleCommand, Guid>
    {
        public IVehicleRepository _vehicleRepository { get; }
        public AuthenticateVehicleCommandHandler(IVehicleRepository vehicleRepository, IServiceInjector serviceInjector) : base(serviceInjector)
        {
            _vehicleRepository = vehicleRepository;
        }
        public async Task<Guid> Handle(AuthenticateVehicleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var vehicle = await _vehicleRepository.GetSingleAsync("VehicleId", request.VehicleId);
                if (vehicle.IsNull())
                    throw new InvalidDataException("invalid username or password");
                vehicle.ValidPassword(request.Password);

                return vehicle.Id;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
