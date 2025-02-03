using Countries.Models;
using Countries.Repositories;
using Countries.Services;

public class CountryBusinessService : ICountryBusinessService
{
    private readonly ICountryService _service;

    public CountryBusinessService(ICountryService service)
    {
        _service = service;
    }

    public async Task<List<Country>> GetCountriesBySeason(string season)
    {
        var countries = await _service.GetAllCountries();
        return countries.Where(c => c.BestSeason.Equals(season, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public async Task<List<Country>> GetCountriesByBudget(decimal maxBudget)
    {
        var countries = await _service.GetAllCountries();
        return countries.Where(c => c.Budget <= maxBudget).ToList();
    }

    public async Task<Country> GetCountryByName(string countryName)
    {
        var countries = await _service.GetAllCountries();
        return countries.FirstOrDefault(c => c.Name.Equals(countryName, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<List<Country>> GetCountriesByContinent(string continent)
    {
        var countries = await _service.GetAllCountries();
        return countries.Where(c => c.Continent.Equals(continent, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public Task AddCountryAsync(Country country)
    {
        throw new NotImplementedException();
    }
}