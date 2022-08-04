using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using CityNews_Application.Interfaces;

using CityNews_Domain.Business.GeocodingApi;

using CityNews_ServiceAgent.GeocodingAPI;

namespace CityNews_Application.Apps {
  public class GeocodingApplication : IGeocodingApplication {

    private readonly IGeocodingAPI clientAPI;

    public GeocodingApplication(IGeocodingAPI client) {
      this.clientAPI = client;
    }
    public async Task<CityData[]> GetCities(string cityName) {      
      return await clientAPI.Get(cityName);
    }
  }
}
