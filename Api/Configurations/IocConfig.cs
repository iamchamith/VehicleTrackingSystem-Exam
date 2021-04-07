using Microsoft.Extensions.DependencyInjection;
using Services.Application;
using Services.Repositories;
using System.Collections;

namespace Api.Configurations
{
    public static class IocConfig
    {
        public static void RegisterIocConfig(this IServiceCollection services)
        {
            services.AddTransient<IServiceInjector, ServiceInjector>();
            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddTransient<ITrackingInfoRepository, TrackingInfoRepository>();
            services.AddTransient<MongoDbContext>(x => new MongoDbContext(new Hashtable {
                {"connectionstring","mongodb://localhost:27017" },
                {"db","VehicleTracker" }
            }));
        }
    }
}
