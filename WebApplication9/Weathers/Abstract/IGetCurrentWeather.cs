using WebApplication9.Models;

namespace WebApplication9.Weathers.Abstract
{
    public interface IGetCurrentWeather<T> where T : class
    {
        Task<T> GetWeather(string city);
    }
}
