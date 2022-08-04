using CityNews_ServiceAgent.GeocodingAPI;
using CityNews_ServiceAgent.NewsAPI;
using CityNews_ServiceAgent.WeatherAPI;

using Microsoft.Extensions.DependencyInjection;

namespace CityNews_ServiceAgent {
  public static class ServiceExtension {
    public static void AddServiceAgent(this IServiceCollection services) {
      services.AddScoped<INewsAPI, NewsApiClient>();
      services.AddScoped<IWeatherAPI, WeatherAPIClient>();
      services.AddScoped<IGeocodingAPI, GeocodingAPIClient>();
    }
  }
}
