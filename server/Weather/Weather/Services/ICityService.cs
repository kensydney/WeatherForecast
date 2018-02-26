using System.Threading.Tasks;

namespace Weather.Services
{
    public interface ICityService
    {
        Task<string> GetCitiesAsync(string country);
    }
}
