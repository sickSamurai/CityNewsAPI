using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Domain.Business.GeocodingApi;

namespace Application.Interfaces {
  public interface IGeocodingApplication {
    public Task<CityObject[]> GetCities(string cityName);
  }
}
