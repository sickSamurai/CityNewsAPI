using Application.Apps;
using Application.Interfaces;

using Microsoft.Extensions.DependencyInjection;

namespace Application {
  public static class ServiceExtension {
    public static void AddApplications(this IServiceCollection services) {
      services.AddScoped<INewsApplication, NewsApplication>();
      services.AddScoped<IHistorialApplication, HistorialApplication>();
      services.AddScoped<IWeatherApplication, WeatherApplication>();
      services.AddScoped<IGeocodingApplication, GeocodingApplication>();
    }
  }
}
