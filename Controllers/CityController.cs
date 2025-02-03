using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Countries.Services;
using Countries.Models;

namespace Countries.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly ILogger<CitiesController> _logger;

        public CitiesController(ICityService cityService, ILogger<CitiesController> logger)
        {
            _cityService = cityService;
            _logger = logger;
        }

        [HttpGet("cities")]
        public async Task<IActionResult> GetCitiesAsync()
        {
            try
            {
                var cities = await _cityService.GetAllCitiesAsync();
                return cities.Any() ? Ok(cities) : NotFound("No cities found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching cities.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
