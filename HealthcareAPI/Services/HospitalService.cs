using HealthcareAPI.DataAccess.Concretes;
using HealthcareAPI.Models;

namespace HealthcareAPI.Services
{
    public class HospitalService
    {
        private readonly MongoRepository _repository;  
        public HospitalService(MongoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Hospital>> GetHospitalsAsync() => await _repository.GetAllAsync();
    }
}
