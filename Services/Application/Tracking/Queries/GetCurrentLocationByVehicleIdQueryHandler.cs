using Core.Entities.Tracking;
using MediatR;
using MongoDB.Driver;
using Services.Dto;
using Services.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Application.Tracking.Queries
{
    public class GetCurrentLocationByVehicleIdQueryHandler : BaseHandler, IRequestHandler<GetCurrentLocationByVehicleIdQuery, TrakingDto>
    {
        public ITrackingInfoRepository _trackingInfoRepository { get; }
        public GetCurrentLocationByVehicleIdQueryHandler(ITrackingInfoRepository trackingInfoRepository, IServiceInjector serviceInjector) : base(serviceInjector)
        {
            _trackingInfoRepository = trackingInfoRepository;
        }
        public async Task<TrakingDto> Handle(GetCurrentLocationByVehicleIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var filtexr = Builders<TrackingInfo>.Filter.Eq("VehicleId", request.VehicleId);
                var item = await _trackingInfoRepository.Collection.Find(filtexr).Sort(Builders<TrackingInfo>.Sort.Descending("DeviceDateTime"))
                    .FirstOrDefaultAsync();
                return _mapper.Map<TrakingDto>(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
