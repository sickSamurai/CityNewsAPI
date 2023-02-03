using Domain.Business.WeatherApi;
using System.Threading.Tasks;

namespace Application.Interfaces {
  public interface IWeatherApplication
    {
        Task<WeatherResponse> GetWeather(double lat, double lon);
    }
}
