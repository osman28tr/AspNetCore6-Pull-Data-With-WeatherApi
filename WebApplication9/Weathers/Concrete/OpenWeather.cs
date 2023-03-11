using WebApplication9.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System;
using WebApplication9.Weathers.Abstract;
using WebApplication9.WeatherApi.Extensions;

namespace WebApplication9.Weathers.Concrete
{
    public class OpenWeather : IOpenWeather
    {
        private readonly WeatherOptions _options;
        private readonly HttpClient _httpClient;
        public OpenWeather(HttpClient httpClient, WeatherOptions options)
        {
            _options = options;
            _httpClient = httpClient;
        }
        //public OpenWeather()
        //{

        //}
        public async Task<WeatherResponse> GetWeather(string city)
        {
            using (var _httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = new Uri("http://api.openweathermap.org");
                var response = await _httpClient.GetAsync($"/data/2.5/weather?q={city}&appid={_options.ApiKey}&units=metric");
                //response.EnsureSuccessStatusCode();

                var stringResult = await response.Content.ReadAsStringAsync();
                var rawWeather = JsonConvert.DeserializeObject<WeatherResponse>(stringResult);


                //return new ResultWeather
                //{
                //    Temp = rawWeather.Main.Temp,
                //    Summary = string.Join(",", rawWeather.Weather.Select(x => x.Main)),
                //    CityName = rawWeather.Name
                //};
                return rawWeather;
            }
        }
    }
}
