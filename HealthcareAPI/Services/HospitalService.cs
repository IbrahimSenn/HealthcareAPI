using HealthcareAPI.DataAccess.Concretes;
using HealthcareAPI.Models;

namespace HealthcareAPI.Services
{
    public class HospitalService
    {
        private readonly MongoRepository<Hospital> _repository;

        public HospitalService(MongoRepository<Hospital> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Hospital>> GetHospitalsAsync() => await _repository.GetAllAsync();

    }
}
