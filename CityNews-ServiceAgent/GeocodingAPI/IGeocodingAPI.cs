using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using CityNews_Domain.Business.GeocodingApi;

namespace CityNews_ServiceAgent.GeocodingAPI {
  public interface IGeocodingAPI {
    public Task<CityData[]> Get(string cityName);
  }
}
