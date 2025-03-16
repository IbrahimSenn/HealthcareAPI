using HealthcareAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareAPI.Controllers
{
    public class HospitalsController : Controller
    {
        private readonly HospitalService _hospitalService;

        public HospitalsController(HospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetHospitals() => Ok(await _hospitalService.GetHospitalsAsync());

    }
}
