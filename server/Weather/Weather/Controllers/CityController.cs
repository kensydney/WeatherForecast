using System.Web.Http;
using Newtonsoft.Json.Linq;
using Weather.Services;
using System.Threading.Tasks;

namespace Weather.Controllers
{
    public class CityController : ApiController
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<JToken> Get(string country)
        {
            if (string.IsNullOrEmpty(country))
                return null;
            var json = await _cityService.GetCitiesAsync(country);
            dynamic data = JObject.Parse(json);
            return data.NewDataSet.Table;
        }
    }
}