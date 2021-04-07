using AutoMapper;
using Core.Entities.Tracking;
using Microsoft.Extensions.DependencyInjection;
using Services.Dto;

namespace Api.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public IServiceCollection _services { get; }
        public AutoMapperConfig(IServiceCollection services)
        {
            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<TrackingInfo, TrakingDto>().ReverseMap();
            _services = services;
        }

        public AutoMapperConfig Register()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(this);
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _services.AddSingleton(mapper);
            return this;
        }
    }
}