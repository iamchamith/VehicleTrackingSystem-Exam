using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Application;
using Services.Repositories;
using System.Collections;

namespace Api.Configurations
{
    public static class IocConfig
    {
        public static void RegisterIocConfig(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IServiceInjector, ServiceInjector>();
            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddTransient<ITrackingInfoRepository, TrackingInfoRepository>();
            services.AddTransient<MongoDbContext>(x => new MongoDbContext(new Hashtable {
                {"connectionstring",config["ConnectionStrings:Server"] },
                {"db",config["ConnectionStrings:Database"]  }
            }));
        }
    }
}
