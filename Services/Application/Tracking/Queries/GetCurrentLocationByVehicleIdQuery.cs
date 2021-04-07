using MediatR;
using Services.Dto;
using System;
namespace Services.Application.Tracking.Queries
{
    public class GetCurrentLocationByVehicleIdQuery : IRequest<TrakingDto>
    {
        public Guid VehicleId { get; private set; } 
        public GetCurrentLocationByVehicleIdQuery(Guid vehicleId)
        {
            VehicleId = vehicleId; 
        }
    }
}
