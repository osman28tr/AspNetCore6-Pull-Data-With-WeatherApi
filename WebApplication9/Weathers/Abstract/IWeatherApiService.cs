using WebApplication9.Models;
using WebApplication9.Models.WeatherApiModels;

namespace WebApplication9.Weathers.Abstract
{
    public interface IWeatherApiService
    {
        Task<WeatherApiResponse> GetWeather(string city);
    }
}
