using Domain.Business.WeatherApi;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAgent.WeatherAPI {
  public interface IWeatherAPI {
    Task<WeatherResponse> Get(double lat, double lon);
  }
}
