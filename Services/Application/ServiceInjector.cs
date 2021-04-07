using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace Services.Application
{
    public interface IServiceInjector
    {
        IConfiguration Configuration { get; set; }
        IMapper Mapper { get; set; }
    }
    public class ServiceInjector : IServiceInjector
    {
        public IConfiguration Configuration { get; set; }
        public IMapper Mapper { get; set; }
        public ServiceInjector(IConfiguration configuration, IMapper mapper)
        {
            Configuration = configuration;
            Mapper = mapper;
        }
    }
}
