using Core.Entities.Tracking;
using Core.Entities.Vehicle;
using MongoDB.Driver;
using System.Collections;

namespace Services.Repositories
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _mongoDb;
        public MongoDbContext(Hashtable connections)
        {
            var _connectionString = connections["connectionstring"].ToString();
            var _db = connections["db"].ToString();
            var client = new MongoClient(_connectionString);
            _mongoDb = client.GetDatabase(_db);
        }
        public IMongoCollection<Vehicle> Vehicles
        {
            get
            {
                return _mongoDb.GetCollection<Vehicle>(nameof(Vehicle));
            }
        }
        public IMongoCollection<TrackingInfo> TrackingInfo
        {
            get
            {
                return _mongoDb.GetCollection<TrackingInfo>(nameof(TrackingInfo));
            }
        }
    }
}
