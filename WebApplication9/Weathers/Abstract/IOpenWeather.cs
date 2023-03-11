using WebApplication9.Models;

namespace WebApplication9.Weathers.Abstract
{
    public interface IOpenWeather:IGetCurrentWeather<WeatherResponse>
    {
    }
}
