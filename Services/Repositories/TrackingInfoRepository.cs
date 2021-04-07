using Core.Entities.Tracking;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public interface ITrackingInfoRepository
    {
        Task Add(TrackingInfo entity);
        Task<List<TrackingInfo>> GetListAsync(FilterDefinition<TrackingInfo> definition);
        Task<List<TrackingInfo>> GetSingleAsync<T>(string filterBy, T value);
        IMongoCollection<TrackingInfo> Collection { get; }
    }
    public class TrackingInfoRepository : ITrackingInfoRepository
    {
        MongoDbContext _dbContext;
        public TrackingInfoRepository(MongoDbContext context)
        {
            _dbContext = context;
        }
        public virtual async Task Add(TrackingInfo entity)
        {
            await _dbContext.TrackingInfo.InsertOneAsync(entity);
        }
        public virtual async Task<List<TrackingInfo>> GetListAsync(FilterDefinition<TrackingInfo> definition)
        {
            return await _dbContext.TrackingInfo.Find(definition).ToListAsync();
        }
        public virtual async Task<List<TrackingInfo>> GetSingleAsync<T>(string filterBy, T value)
        {
            var filtexr = Builders<TrackingInfo>.Filter.Eq(filterBy, value);
            return await _dbContext.TrackingInfo.Find(filtexr).ToListAsync();
        }

        public IMongoCollection<TrackingInfo> Collection
        {
            get { return _dbContext.TrackingInfo; }
        }
    }
}
