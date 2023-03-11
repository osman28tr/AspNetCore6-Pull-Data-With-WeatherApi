using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System.ComponentModel;
using WebApplication9.Controllers;
using WebApplication9.WeatherApi.Extensions;
using WebApplication9.Weathers.Abstract;
using WebApplication9.Weathers.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddHttpClient();

// Register WeatherClientFactory and IGetCurrentWeather services.
builder.Services.AddTransient<WeatherClientFactory>();
//builder.Services.AddSingleton<IWeatherService,WeatherManager>();
builder.Services.AddSingleton<IWeatherApiService, WeatherApiManager>();

builder.Services.AddTransient<IWeatherApi, WeatherApi>(provider =>
{
    var factory = provider.GetRequiredService<WeatherClientFactory>();
    var options = provider.GetRequiredService<IOptions<WeatherOptions>>().Value;
    options.ApiKey = "d1398cba8a894feb9f7180821232602";
    return new WeatherApi(factory.CreateClient(), options);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
