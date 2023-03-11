using Newtonsoft.Json;
using WebApplication9.Models;
using WebApplication9.WeatherApi.Extensions;
using WebApplication9.Weathers.Abstract;

namespace WebApplication9.Weathers.Concrete
{
    public class WeatherApi : IGetCurrentWeather
    {
        private readonly WeatherOptions _options;
        private readonly HttpClient _httpClient;
        public WeatherApi(HttpClient httpClient, WeatherOptions options)
        {
            _options = options;
            _httpClient = httpClient;
        }
        public async Task<WeatherResponse> GetWeather(string city)
        {
            _httpClient.BaseAddress = new Uri("http://api.weatherapi.com");
            var response = await _httpClient.GetAsync($"http://api.weatherapi.com/v1/current.json?key={_options.ApiKey}&q={city}&aqi=no");
            //response.EnsureSuccessStatusCode();

            var stringResult = await response.Content.ReadAsStringAsync();
            var rawWeather = JsonConvert.DeserializeObject<WeatherResponse>(stringResult);


            //return new WeatherResponse
            //{
            //    Temp = rawWeather.Main.Temp,
            //    Summary = string.Join(",", rawWeather.Weather.Select(x => x.Main)),
            //    CityName = rawWeather.Name
            //};
            return rawWeather;
        }
    }
}
