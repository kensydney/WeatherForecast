using System.Web.Http;
using Newtonsoft.Json.Linq;
using Weather.Services;
using System.Threading.Tasks;

namespace Weather.Controllers
{
    public class WeatherController : ApiController
    {

        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<JToken> Get(string country, string city)
        {
            if (string.IsNullOrEmpty(country) || string.IsNullOrEmpty(city))
                return null;

            var json = await _weatherService.GetWeatherAsync(country, city);

            return JObject.Parse(json);
        }

    }
}