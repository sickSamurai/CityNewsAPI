using CityNews_Domain.Business.WeatherApi;
using System.Threading.Tasks;

namespace CityNews_Application.Interfaces {
  public interface IWeatherApplication
    {
        Task<WeatherResponse> GetWeatherInfo(double lat, double lon);
    }
}
