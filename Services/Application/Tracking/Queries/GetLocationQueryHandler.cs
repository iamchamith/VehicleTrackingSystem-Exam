using Core.Entities.Tracking;
using MediatR;
using MongoDB.Driver;
using Services.Dto;
using Services.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Application.Tracking.Queries
{
    public class GetLocationQueryHandler : BaseHandler, IRequestHandler<GetLocationQuery, List<TrakingDto>>
    {
        public ITrackingInfoRepository _trackingInfoRepository { get; }
        public GetLocationQueryHandler(ITrackingInfoRepository trackingInfoRepository, IServiceInjector serviceInjector) : base(serviceInjector)
        {
            _trackingInfoRepository = trackingInfoRepository;
        }
        public async Task<List<TrakingDto>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var filter = Builders<TrackingInfo>.Filter.And(
                   Builders<TrackingInfo>.Filter.Where(p => p.DeviceDateTime > request.FromDateTime),
                    Builders<TrackingInfo>.Filter.Where(p => p.DeviceDateTime < request.ToDateTime),
                   Builders<TrackingInfo>.Filter.Where(p => p.VehicleId == request.VehicleId)
             );
                var items = await _trackingInfoRepository.GetListAsync(filter);
                return _mapper.Map<List<TrakingDto>>(items);
            }
            catch (Exception)
            {
                throw;
            }           
        }
    }
}
