using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
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
builder.Services.AddSingleton<WeatherClientFactory>();
builder.Services.AddSingleton<IWeatherService,WeatherManager>();
builder.Services.AddTransient<IGetCurrentWeather, OpenWeather>(provider =>
{
    var factory = provider.GetRequiredService<WeatherClientFactory>();
    var options = provider.GetRequiredService<IOptions<WeatherOptions>>().Value;
    options.ApiKey = "cbc3a0fb93331cfb4672c89b1d9b55d9";
    return new OpenWeather(factory.CreateClient(), options);
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
