using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using CityNews_Domain.Business.GeocodingApi;

namespace CityNews_Application.Interfaces {
  public interface IGeocodingApplication {
    public Task<CityData[]> GetCities(string cityName);
  }
}
