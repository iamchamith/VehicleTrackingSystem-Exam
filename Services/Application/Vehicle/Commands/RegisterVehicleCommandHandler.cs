using MediatR;
using Services.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Application.Vehicle.Commands
{
    public class RegisterVehicleCommandHandler : BaseHandler, IRequestHandler<RegisterVehicleCommand, string>
    {
        public IVehicleRepository _vehicleRepository { get; }
        public RegisterVehicleCommandHandler(IVehicleRepository vehicleRepository, IServiceInjector serviceInjector)
            : base(serviceInjector)
        {
            _vehicleRepository = vehicleRepository;
        }
        public async Task<string> Handle(RegisterVehicleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var password = Guid.NewGuid().ToString().Split("-")[0]; 
                await _vehicleRepository.Add(new Core.Entities.Vehicle.Vehicle(request.VehicleId.ToLower(), password));
                return password;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
