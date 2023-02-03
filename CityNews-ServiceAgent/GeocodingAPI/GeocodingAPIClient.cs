using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Domain.Business.GeocodingApi;

using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;

namespace ServiceAgent.GeocodingAPI {
  public class GeocodingAPIClient : IGeocodingAPI {
    private readonly IConfiguration configuration;
    public GeocodingAPIClient(IConfiguration configuration) {
      this.configuration = configuration;
    }
    public async Task<CityObject[]> Get(string cityName) {
      var baseAddress = configuration["OpenWeatherApi:BaseAddress"];
      var path = configuration["OpenWeatherApi:GeocodingPath"];
      var query = configuration["OpenWeatherApi:GeocodingQuery"];
      var appID = configuration["OpenWeatherApi:Key"];
      string formatedQuery = string.Format(query, cityName, appID);
      string completeURL = $"{baseAddress}{path}{formatedQuery}";
      var responseAsJSON = await new HttpClient().GetStringAsync(completeURL);
      var responseAsObject = JsonConvert.DeserializeObject<CityObject[]>(responseAsJSON);
      return responseAsObject;
    }
  }
}
