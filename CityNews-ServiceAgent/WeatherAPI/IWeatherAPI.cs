using CityNews_Domain.Business.WeatherApi;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CityNews_ServiceAgent.WeatherAPI {
  public interface IWeatherAPI {
    Task<WeatherResponse> Get(double lat, double lon);
  }
}
