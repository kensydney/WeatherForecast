using System.Web.Http;
using Newtonsoft.Json.Linq;
using Weather.Services;

namespace Weather.Controllers
{
    public class CountryController : ApiController
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public JToken Get()
        {            
            var json = _countryService.GetCountries();
            return JArray.Parse(json);
        }

    }
}