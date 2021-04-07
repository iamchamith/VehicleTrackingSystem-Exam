using Core.Entities.Tracking;
using MediatR;
using Services.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Services.Application.Tracking.Commands
{
    public class AddTrackInfoCommandHandler : BaseHandler, IRequestHandler<AddTrackInfoCommand, Unit>
    {
        public ITrackingInfoRepository _trackingInfoRepository { get; }
        public AddTrackInfoCommandHandler(ITrackingInfoRepository trackingInfoRepository, IServiceInjector serviceInjector) : base(serviceInjector)
        {
            _trackingInfoRepository = trackingInfoRepository;
        }
        public Task<Unit> Handle(AddTrackInfoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _trackingInfoRepository.Add(new TrackingInfo(request.VehicleId, request.DeviceDateTime)
                    .AddLocation(request.Location.Lat,request.Location.Long));
                return Task.FromResult(Unit.Value);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
