using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Application.Interfaces;

using ServiceAgent.GeocodingAPI;

using Domain.Business.GeocodingApi;

namespace Application.Apps {
  public class GeocodingApplication : IGeocodingApplication {

    private readonly IGeocodingAPI clientAPI;

    public GeocodingApplication(IGeocodingAPI client) {
      this.clientAPI = client;
    }
    public async Task<CityObject[]> GetCities(string cityName) {      
      return await clientAPI.Get(cityName);
    }
  }
}
