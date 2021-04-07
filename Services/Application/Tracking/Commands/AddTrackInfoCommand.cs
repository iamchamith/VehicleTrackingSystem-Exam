using Core.Entities.Tracking;
using MediatR;
using Services.Dto;
using System;
namespace Services.Application.Tracking.Commands
{
    public class AddTrackInfoCommand : IRequest
    {
        public Guid VehicleId { get; private set; }
        public DateTime DeviceDateTime { get; set; }
        public LocationDto Location { get; set; }

        public AddTrackInfoCommand AddVehicleId(Guid vehicleId) {

            VehicleId = vehicleId;
            return this;
        }
    }
}
