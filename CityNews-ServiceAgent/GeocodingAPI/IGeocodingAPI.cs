using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Domain.Business.GeocodingApi;

namespace ServiceAgent.GeocodingAPI {
  public interface IGeocodingAPI {
    public Task<CityObject[]> Get(string cityName);
  }
}
