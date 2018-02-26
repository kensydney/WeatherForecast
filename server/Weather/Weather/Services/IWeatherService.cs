using System.Threading.Tasks;

namespace Weather.Services
{
    public interface IWeatherService
    {
        Task<string> GetWeatherAsync(string country, string city);
    }
}
