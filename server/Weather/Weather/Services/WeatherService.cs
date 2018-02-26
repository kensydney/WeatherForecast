using System;
using Weather.Models;
using Newtonsoft.Json;
using Weather.Helpers;
using System.Threading.Tasks;

namespace Weather.Services
{
    public class WeatherService: IWeatherService
    {
        public async Task<string> GetWeatherAsync(string country, string city)
        {
            WeatherServiceRef.GlobalWeatherSoap obj = new WeatherServiceRef.GlobalWeatherSoapClient();
            var forecast = await obj.GetWeatherAsync(country, city);
            if (forecast.IndexOf("Data Not Found") >= 0)
            {
                //no data available build a mock object
                var fc = new Forecast()
                {
                    Location = "Mock Location",
                    Time = DateTime.Now.AddDays(1).ToShortDateString(),
                    Wind = "16km/h",
                    Visibility = "yes",
                    Sky = "cloudy",
                    Temp = "20 degree",
                    Dew = "16 degree",
                    Humidity = "80%",
                    Presurre = "1000hpa"
                };
                return JsonConvert.SerializeObject(fc).ToString();
            }
            else
                return JsonHelper.processWeatherResult(forecast);
        }
    }
}