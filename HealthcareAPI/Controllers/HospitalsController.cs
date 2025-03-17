using HealthcareAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HospitalsController : ControllerBase
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
