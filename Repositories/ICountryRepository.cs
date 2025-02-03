using Countries.Models;

namespace Countries.Repositories
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllAsync();
        Task<Country> GetByIdAsync(int id);
        Task AddAsync(Country country);
        Task UpdateAsync(Country country);
        Task DeleteAsync(int id);
    }
}
