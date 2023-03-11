using WebApplication9.Models;
using WebApplication9.Weathers.Abstract;

namespace WebApplication9.Weathers.Concrete
{
    public class WeatherManager : IWeatherService
    {
        private readonly IGetCurrentWeather _getCurrentWeather;
        public WeatherManager(IGetCurrentWeather getCurrentWeather)
        {
            _getCurrentWeather = getCurrentWeather;
        }
        public async Task<WeatherResponse> GetWeather(string city)
        {
           return await _getCurrentWeather.GetWeather(city);
        }
    }
}
