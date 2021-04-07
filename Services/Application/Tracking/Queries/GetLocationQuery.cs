using MediatR;
using Services.Dto;
using System;
using System.Collections.Generic;
namespace Services.Application.Tracking.Queries
{
    public class GetLocationQuery : IRequest<List<TrakingDto>>
    {
        public Guid VehicleId { get; private set; }
        public DateTime FromDateTime { get; private set; }
        public DateTime ToDateTime { get; private set; }
        public GetLocationQuery(Guid vehicleId, DateTime fromDateTime, DateTime toDateTime)
        {
            VehicleId = vehicleId;
            FromDateTime = fromDateTime;
            ToDateTime = toDateTime;
        }
    }
}
