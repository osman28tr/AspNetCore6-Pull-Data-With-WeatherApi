using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication9.Models;
using WebApplication9.Weathers.Abstract;
using WebApplication9.Weathers.Concrete;

namespace WebApplication9.Controllers
{
    
    public class WeatherController : Controller
    {
        
        IGetCurrentWeather _getCurrentWeather;
        IWeatherService _weatherService;
        public WeatherController(IGetCurrentWeather getCurrentWeather,IWeatherService weatherService)
        {
            _getCurrentWeather = getCurrentWeather;
            _weatherService = weatherService;
        }
        
        public IActionResult Index()
        {           
            return View();
        }   
        [HttpPost]
        public async Task<IActionResult> Index(Weather weather)
        {
            var weatherStatistic = await _weatherService.GetWeather(weather.CityName);
            if (weather.IsFahrenheit == true)
                weatherStatistic.Main.Temp = (Convert.ToDouble(weatherStatistic.Main.Temp) * 1.8 + 32).ToString() + "°F";
            else
                weatherStatistic.Main.Temp = weatherStatistic.Main.Temp + "°C";
            ViewBag.City = weatherStatistic.Name;
            ViewBag.summary = string.Join(",", weatherStatistic.Weather.Select(x => x.Main));
            ViewBag.Temp = weatherStatistic.Main.Temp;
            return View();
        }
    }
}
