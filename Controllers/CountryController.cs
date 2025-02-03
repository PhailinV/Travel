using Microsoft.AspNetCore.Mvc;
using Countries.Services;
using Countries.Models;
using Microsoft.Extensions.Logging;
using FluentValidation;
using System;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CountryController : ControllerBase
{
    private readonly ICountryBusinessService _businessService;
    private readonly ICityService _cityService;
    private readonly ILogger<CountryController> _logger;
    private readonly IValidator<Country> _countryValidator;
    private readonly IValidator<City> _cityValidator;

    public CountryController(
        ICountryBusinessService businessService,
        ICityService cityService,
        ILogger<CountryController> logger,
        IValidator<Country> countryValidator,
        IValidator<City> cityValidator)
    {
        _businessService = businessService ?? throw new ArgumentNullException(nameof(businessService));
        _cityService = cityService ?? throw new ArgumentNullException(nameof(cityService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _countryValidator = countryValidator ?? throw new ArgumentNullException(nameof(countryValidator));
        _cityValidator = cityValidator ?? throw new ArgumentNullException(nameof(cityValidator));
    }

    [HttpGet("season/{season}")]
    public async Task<IActionResult> GetCountriesBySeason(string season)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(season))
                return BadRequest("Season is required.");

            var countries = await _businessService.GetCountriesBySeason(season);
            return countries.Any() ? Ok(countries) : NotFound("No countries found for the specified season.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while fetching countries by season.");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("budget/{maxBudget}")]
    public async Task<IActionResult> GetCountriesByBudget(decimal maxBudget)
    {
        try
        {
            if (maxBudget <= 0)
                return BadRequest("Budget must be greater than zero.");

            var countries = await _businessService.GetCountriesByBudget(maxBudget);
            return countries.Any() ? Ok(countries) : NotFound("No countries found within the specified budget.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while fetching countries by budget.");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost("add-country")]
    public async Task<IActionResult> AddCountry([FromBody] Country country)
    {
        var validationResult = await _countryValidator.ValidateAsync(country);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        await _businessService.AddCountryAsync(country);
        return Ok("Country added successfully.");
    }

    [HttpPost("add-city")]
    public async Task<IActionResult> AddCity([FromBody] City city)
    {
        var validationResult = await _cityValidator.ValidateAsync(city);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        await _cityService.AddCityAsync(city);
        return Ok("City added successfully.");
    }

    [HttpGet("cities")]
    public async Task<IActionResult> GetAllCities()
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