using Microsoft.Extensions.DependencyInjection;
using ServiceAgent.WeatherAPI;
using ServiceAgent.GeocodingAPI;
using ServiceAgent.NewsAPI;

namespace ServiceAgent {
  public static class ServiceExtension {
    public static void AddServiceAgent(this IServiceCollection services) {
      services.AddScoped<INewsAPI, NewsApiClient>();
      services.AddScoped<IWeatherAPI, WeatherAPIClient>();
      services.AddScoped<IGeocodingAPI, GeocodingAPIClient>();
    }
  }
}
