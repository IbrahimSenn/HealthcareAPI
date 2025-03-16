using HealthcareAPI.Models;
using MongoDB.Driver;

namespace HealthcareAPI.DataAccess.Contexts
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDB"));
            _database = client.GetDatabase("HealthcareDB");
        }

        public IMongoCollection<Hospital> Hospitals => _database.GetCollection<Hospital>("Hospitals");


    }
}
