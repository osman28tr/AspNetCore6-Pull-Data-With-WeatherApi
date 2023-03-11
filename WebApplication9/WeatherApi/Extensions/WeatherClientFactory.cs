using WebApplication9.Weathers.Abstract;
using WebApplication9.Weathers.Concrete;
using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace WebApplication9.WeatherApi.Extensions
{
    public class WeatherClientFactory
    {
        //public static IHttpClientBuilder AddWeatherApi(this /*IServiceCollection services,*/IHttpClientBuilder builder, Action<WeatherOptions> configureOptions)
        //{
        //    var options = new WeatherOptions();
        //    configureOptions?.Invoke(options);

        //    builder.Services.AddSingleton(options);
        //    builder.Services.AddTransient<IGetCurrentWeather, OpenWeather>();

        //    return builder;
        //}

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly WeatherOptions _options;

        public WeatherClientFactory(IHttpClientFactory httpClientFactory, IOptions<WeatherOptions> options)
        {
            _httpClientFactory = httpClientFactory;
            _options = options.Value;
        }

        public HttpClient CreateClient()
        {
            var client = _httpClientFactory.CreateClient();
            //client.BaseAddress = new Uri(_options.ApiKey);

            return client;
        }
    }
}
