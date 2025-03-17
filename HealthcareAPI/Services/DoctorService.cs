using HealthcareAPI.DataAccess.Abstracts;
using HealthcareAPI.DataAccess.Concretes;
using HealthcareAPI.Models;
using Microsoft.Extensions.Logging;

namespace HealthcareAPI.Services
{
    public class DoctorService 
    {
        //private readonly Repository<Doctor> _repository;
        private readonly IRepository<Doctor> _doctorRepository;

        public DoctorService(IRepository<Doctor> doctorRepository)
        {
            _doctorRepository = doctorRepository;

        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            try
            {
                return await _doctorRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                
                throw; // Rethrow exception after logging it
            }
        }
        public async Task AddDoctorAsync(Doctor doctor) => await _doctorRepository.AddAsync(doctor);
    }
}

