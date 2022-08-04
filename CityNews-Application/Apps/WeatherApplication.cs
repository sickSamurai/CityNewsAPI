using CityNews_Application.Interfaces;

using CityNews_Domain.Business.WeatherApi;

using CityNews_ServiceAgent.WeatherAPI;

using System;
using System.Threading.Tasks;

namespace CityNews_Application.Apps {
  public class WeatherApplication : IWeatherApplication
    {
        private readonly IWeatherAPI weatherAPI;
        public WeatherApplication(IWeatherAPI weatherAPI) {
            this.weatherAPI = weatherAPI;
        }

        public async Task<WeatherResponse> GetWeatherInfo(double lat, double lon) {
            return await weatherAPI.Get(lat, lon);            
        }
    }
}
