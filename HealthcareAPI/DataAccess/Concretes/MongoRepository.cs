using MongoDB.Driver;

namespace HealthcareAPI.DataAccess.Concretes
{
    public class MongoRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepository(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();
        public async Task<T> GetByIdAsync(string id) => await _collection.Find(Builders<T>.Filter.Eq("_id", id)).FirstOrDefaultAsync();
        public async Task AddAsync(T entity) => await _collection.InsertOneAsync(entity);
        public async Task DeleteAsync(string id) => await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id));
    }
}
