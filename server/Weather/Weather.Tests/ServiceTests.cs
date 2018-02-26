using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Weather;
using Weather.Services;
using System.Threading.Tasks;

namespace Weather.Tests
{
    [TestClass]
    public class ServiceTests
    {
        [TestMethod]
        public async Task CityServiceTest()
        {
            WeatherServiceRef.GlobalWeatherSoap obj = new WeatherServiceRef.GlobalWeatherSoapClient();
            var cities = await obj.GetCitiesByCountryAsync("Australia");
            Assert.IsNotNull(cities);
            Assert.IsTrue(cities.IndexOf("Sydney") >= 0);          
        }

        [TestMethod]
        public async Task WeatherServiceTest()
        {
            WeatherServiceRef.GlobalWeatherSoap obj = new WeatherServiceRef.GlobalWeatherSoapClient();
            var weather = await obj.GetWeatherAsync("Australia", "Sydney Airport");
            Assert.IsNotNull(weather);
        }

        [TestMethod]
        public void CountryServiceTest()
        {
            CountryService ws = new CountryService();
            var countries = ws.GetCountries();
            Assert.IsNotNull(countries);
            Assert.IsTrue(countries.IndexOf("Australia") >= 0);
        }
    }
}
