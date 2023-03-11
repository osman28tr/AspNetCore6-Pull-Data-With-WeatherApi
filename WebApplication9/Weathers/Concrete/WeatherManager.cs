using WebApplication9.Models;
using WebApplication9.Weathers.Abstract;

namespace WebApplication9.Weathers.Concrete
{
    public class WeatherManager : IWeatherService
    {
        private readonly IOpenWeather _openWeather;
        public WeatherManager(IOpenWeather openWeather)
        {
            _openWeather = openWeather;
        }
        public async Task<WeatherResponse> GetWeather(string city)
        {
           return await _openWeather.GetWeather(city);
        }
    }
}
