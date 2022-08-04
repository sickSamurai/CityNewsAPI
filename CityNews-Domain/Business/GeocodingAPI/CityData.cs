using System;
using System.Collections.Generic;
using System.Text;

namespace CityNews_Domain.Business.GeocodingApi {
  public class CityData {
    public string Name { get; set; }
    public string Country { get; set; }
    public double Lat { get; set; }
    public double Lon { get; set; }
  }
}
