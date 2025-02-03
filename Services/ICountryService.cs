using Countries.Models;

namespace Countries.Services
{
    public interface ICountryService
    {
        Task<List<Country>> GetAllCountries();
        Task AddCountry(Country country);
    }
}
