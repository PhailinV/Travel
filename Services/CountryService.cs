using Countries.Models;
using Countries.Repositories;

namespace Countries.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _repository;

        public CountryService(ICountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Country>> GetAllCountries() => await _repository.GetAllAsync();
        public async Task AddCountry(Country country) => await _repository.AddAsync(country);
    }
}
