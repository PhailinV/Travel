using Countries.Models;

public interface ICityService
{
    Task<IEnumerable<City>> GetAllCitiesAsync();
    Task AddCityAsync(City city); 
}
