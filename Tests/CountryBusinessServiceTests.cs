using Countries.Models;
using Countries.Services;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Countries.Tests
{
    public class CountryBusinessServiceTests
    {
        [Fact]
        public async Task GetCountriesBySeason_ReturnsFilteredCountries()
        {
            var mockService = new Mock<ICountryService>();
            mockService.Setup(s => s.GetAllCountries()).ReturnsAsync(new List<Country>
        {
            new Country { Name = "France", BestSeason = "Summer", Budget = 1500, Continent = "Europe" },
            new Country { Name = "Canada", BestSeason = "Winter", Budget = 2000, Continent = "North America" }
        });

            var businessService = new CountryBusinessService(mockService.Object);
            var result = await businessService.GetCountriesBySeason("Summer");

            Assert.Single(result);
            Assert.Equal("France", result[0].Name);
        }
    }
}
