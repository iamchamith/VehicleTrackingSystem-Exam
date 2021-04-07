using Core.Entities.Vehicle;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public interface IVehicleRepository
    {
        Task Add(Vehicle entity);
        Task<List<Vehicle>> GetListAsync<T>(string filterBy, T value);
        Task<List<Vehicle>> GetListAsync(FilterDefinition<Vehicle> definition);
        Task<Vehicle> GetSingleAsync(FilterDefinition<Vehicle> definition);
        Task<Vehicle> GetSingleAsync<T>(string filterBy, T value);
    }
    public class VehicleRepository : IVehicleRepository
    {
        MongoDbContext _dbContext;
        public VehicleRepository(MongoDbContext context)
        {
            _dbContext = context;
        }
        public virtual async Task Add(Vehicle entity)
        {
            await _dbContext.Vehicles.InsertOneAsync(entity);
        }
        public virtual async Task<List<Vehicle>> GetListAsync<T>(string filterBy, T value)
        {
            var filtexr = Builders<Vehicle>.Filter.Eq(filterBy, value);
            return await _dbContext.Vehicles.Find(filtexr).ToListAsync();
        }
        public virtual async Task<List<Vehicle>> GetListAsync(FilterDefinition<Vehicle> definition)
        {
            return await _dbContext.Vehicles.Find(definition).ToListAsync();
        }
        public virtual async Task<Vehicle> GetSingleAsync(FilterDefinition<Vehicle> definition)
        {
            return await _dbContext.Vehicles.Find(definition).SingleOrDefaultAsync();
        }
        public virtual async Task<Vehicle> GetSingleAsync<T>(string filterBy, T value)
        {
            var filtexr = Builders<Vehicle>.Filter.Eq(filterBy, value);
            return await _dbContext.Vehicles.Find(filtexr).SingleOrDefaultAsync();
        }
    }
}
