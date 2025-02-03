using Countries.Models;
using Countries.Services;

public class CityService : ICityService
{
    public Task AddCityAsync(City city)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<City>> GetAllCitiesAsync()
    {
        // Примерен списък с градове
        var cities = new List<City>
        {
            new City { Name = "Seoul" },
            new City { Name = "Kyoto" }
        };

        return await Task.FromResult(cities);
    }
}
