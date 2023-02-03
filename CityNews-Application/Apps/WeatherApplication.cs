using Application.Interfaces;

using ServiceAgent.WeatherAPI;

using Domain.Business.WeatherApi;

using System;
using System.Threading.Tasks;

namespace Application.Apps {
  public class WeatherApplication : IWeatherApplication
    {
        private readonly IWeatherAPI weatherAPI;
        public WeatherApplication(IWeatherAPI weatherAPI) {
            this.weatherAPI = weatherAPI;
        }

        public async Task<WeatherResponse> GetWeather(double lat, double lon) {
            return await weatherAPI.Get(lat, lon);            
        }
    }
}
