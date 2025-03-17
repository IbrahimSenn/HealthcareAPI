using HealthcareAPI.DataAccess.Abstracts;
using HealthcareAPI.Models;
using MongoDB.Driver;

namespace HealthcareAPI.DataAccess.Concretes
{
    public class MongoRepository : IMongoRepository<Hospital>
    {
        private readonly IMongoCollection<Hospital> _collection;

        public MongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Hospital>("Hospitals");
        }

        public async Task<IEnumerable<Hospital>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();
        public async Task<Hospital> GetByIdAsync(string id) => await _collection.Find(Builders<Hospital>.Filter.Eq("_id", id)).FirstOrDefaultAsync();
        public async Task AddAsync(Hospital entity) => await _collection.InsertOneAsync(entity);
        public async Task DeleteAsync(string id) => await _collection.DeleteOneAsync(Builders<Hospital>.Filter.Eq("_id", id));
    }
}
