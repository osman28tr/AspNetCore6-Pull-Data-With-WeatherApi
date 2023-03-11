using Microsoft.AspNetCore.Mvc;
using WebApplication9.Models;
using WebApplication9.Weathers.Abstract;

namespace WebApplication9.Controllers
{
    public class WeatherApiController : Controller
    {
        IWeatherApi _weatherApi;
        IWeatherApiService _weatherApiService;
        public WeatherApiController(IWeatherApi weatherApi, IWeatherApiService weatherApiService)
        {
            _weatherApi = weatherApi;
            _weatherApiService = weatherApiService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Weather weather)
        {
            var weatherStatistic = await _weatherApiService.GetWeather(weather.CityName);
            if (weather.IsFahrenheit == true)
            {
                weatherStatistic.current.temp_c = weatherStatistic.current.temp_c * 1.8F + 32;
                ViewBag.Temp = (weatherStatistic.current.temp_c).ToString() + "°F";
            }
            else
            {
                weatherStatistic.current.temp_c = weatherStatistic.current.temp_c;
                ViewBag.Temp = (weatherStatistic.current.temp_c).ToString() + "°C";
            }            
            ViewBag.City = weatherStatistic.location.name;
            return View();
        }
    }
}