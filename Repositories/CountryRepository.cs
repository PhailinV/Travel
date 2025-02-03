using Countries.Models;
using Countries.Repositories;

public class CountryRepository : ICountryRepository
{
    private readonly List<Country> _countries = new();

    public CountryRepository()
    {
        _countries.AddRange(new List<Country>
        {
            new Country { Id = 1, Name = "Brazil", BestSeason = "Winter", Budget = 1000, Continent = "South America" },
            new Country { Id = 2, Name = "Switzerland", BestSeason = "Winter", Budget = 2000, Continent = "Europe" },
            new Country { Id = 3, Name = "Japan", BestSeason = "Spring", Budget = 1800, Continent = "Asia" },
            new Country { Id = 4, Name = "South Korea", BestSeason = "Spring", Budget = 1800, Continent = "Asia" },
            new Country { Id = 5, Name = "China", BestSeason = "Fall", Budget = 1800, Continent = "Asia" },
            new Country { Id = 6, Name = "Peru", BestSeason = "Spring", Budget = 1000, Continent = "South America" },
            new Country { Id = 7, Name = "Greece", BestSeason = "Summer", Budget = 1000, Continent = "Europe" },
            new Country { Id = 8, Name = "Canada", BestSeason = "Winter", Budget = 1800, Continent = "North America" },
            new Country { Id = 9, Name = "Sweden", BestSeason = "Summer", Budget = 2000, Continent = "Europe" }
        });
    }

    public async Task<List<Country>> GetAllAsync() => await Task.FromResult(_countries);

    public async Task<Country> GetByIdAsync(int id) => await Task.FromResult(_countries.FirstOrDefault(c => c.Id == id));

    public async Task AddAsync(Country country)
    {
        _countries.Add(country);
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Country country)
    {
        var index = _countries.FindIndex(c => c.Id == country.Id);
        if (index != -1)
            _countries[index] = country;
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        _countries.RemoveAll(c => c.Id == id);
        await Task.CompletedTask;
    }
}
