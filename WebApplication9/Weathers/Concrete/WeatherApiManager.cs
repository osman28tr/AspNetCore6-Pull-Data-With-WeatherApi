using WebApplication9.Models;
using WebApplication9.Models.WeatherApiModels;
using WebApplication9.Weathers.Abstract;

namespace WebApplication9.Weathers.Concrete
{
    public class WeatherApiManager : IWeatherApiService
    {
        private readonly IWeatherApi _weatherApi;
        public WeatherApiManager(IWeatherApi weatherApi)
        {
            _weatherApi = weatherApi;
        }
        public async Task<WeatherApiResponse> GetWeather(string city)
        {
            return await _weatherApi.GetWeather(city);
        }
    }
}
