using HealthcareAPI.DataAccess.Concretes;
using HealthcareAPI.Models;

namespace HealthcareAPI.Services
{
    public class DoctorService
    {
        private readonly Repository<Doctor> _repository;

        public DoctorService(Repository<Doctor> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync() => await _repository.GetAllAsync();
        public async Task AddDoctorAsync(Doctor doctor) => await _repository.AddAsync(doctor);
    }
}

