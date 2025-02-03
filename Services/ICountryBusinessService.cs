using Countries.Models;

public interface ICountryBusinessService
{
    Task<List<Country>> GetCountriesBySeason(string season);
    Task<List<Country>> GetCountriesByBudget(decimal maxBudget);
    Task<Country> GetCountryByName(string countryName);
    Task<List<Country>> GetCountriesByContinent(string continent);
    Task AddCountryAsync(Country country);
}