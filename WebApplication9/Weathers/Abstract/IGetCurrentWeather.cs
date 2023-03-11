using WebApplication9.Models;

namespace WebApplication9.Weathers.Abstract
{
    public interface IGetCurrentWeather
    {
        Task<WeatherResponse> GetWeather(string city);
    }
}
