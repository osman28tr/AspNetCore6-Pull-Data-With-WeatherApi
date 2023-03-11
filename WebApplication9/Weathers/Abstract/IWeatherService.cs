using WebApplication9.Models;

namespace WebApplication9.Weathers.Abstract
{
    public interface IWeatherService
    {
        Task<WeatherResponse> GetWeather(string city);
    }
}
