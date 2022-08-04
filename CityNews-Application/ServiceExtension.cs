using CityNews_Application.Apps;
using CityNews_Application.Interfaces;

using Microsoft.Extensions.DependencyInjection;

namespace CityNews_Application {
  public static class ServiceExtension {
    public static void AddApplications(this IServiceCollection services) {
      services.AddScoped<ICityNewsApplication, CityNewsApplication>();
      services.AddScoped<IHistorialApplication, HistorialApplication>();
      services.AddScoped<IWeatherApplication, WeatherApplication>();
      services.AddScoped<IGeocodingApplication, GeocodingApplication>();
    }
  }
}
