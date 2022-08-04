using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using CityNews_Domain.Business.WeatherApi;

using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;

namespace CityNews_ServiceAgent.WeatherAPI {
  public class WeatherAPIClient : IWeatherAPI {
    private readonly IConfiguration configuration;

    public WeatherAPIClient(IConfiguration configuration) {
      this.configuration = configuration;
    }

    public async Task<WeatherResponse> Get(double lat, double lon) {
      var baseAddress = configuration["OpenWeatherApi:BaseAddress"];
      var path = configuration["OpenWeatherApi:WeatherPath"];
      var query = configuration["OpenWeatherApi:WeatherQuery"];
      var appID = configuration["OpenWeatherApi:Key"];
      var formatedQuery = string.Format(query, lat, lon, appID);
      var completeURL = $"{baseAddress}{path}{formatedQuery}";
      var responseAsJSON = await new HttpClient().GetStringAsync(completeURL);
      var response = JsonConvert.DeserializeObject<WeatherResponse>(responseAsJSON);
      return response;
    }

  }
}
