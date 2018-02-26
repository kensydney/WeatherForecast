using Weather.Helpers;
using System.Threading.Tasks;

namespace Weather.Services
{
    public class CityService: ICityService
    {
        public async Task<string> GetCitiesAsync(string country)
        {
            WeatherServiceRef.GlobalWeatherSoap obj = new WeatherServiceRef.GlobalWeatherSoapClient();
            var cities = await obj.GetCitiesByCountryAsync(country);
            var json = JsonHelper.processWeatherResult(cities);            
            return json;
        }
    }
}