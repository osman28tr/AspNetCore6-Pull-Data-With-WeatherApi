using WebApplication9.Models.WeatherApiModels;

namespace WebApplication9.Weathers.Abstract
{
    public interface IWeatherApi:IGetCurrentWeather<WeatherApiResponse>
    {
    }
}
