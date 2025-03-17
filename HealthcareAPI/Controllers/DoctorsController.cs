using HealthcareAPI.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DoctorsController : ControllerBase
{
    private readonly DoctorService _doctorService;

    // DoctorService injection
    public DoctorsController(DoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetDoctors()
    {
        try
        {
            var doctors = await _doctorService.GetDoctorsAsync();
            return Ok(doctors);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
