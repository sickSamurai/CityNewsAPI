using System;
using System.Linq;
using System.Threading.Tasks;

using CityNews_Application.Interfaces;

using CityNews_Domain.Business.GeocodingApi;
using CityNews_Domain.Entities;

using CityNews_Persistence.Context;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

namespace CityNews_Application.Apps {
  internal class HistorialApplication : IHistorialApplication {

    private readonly HistorialContext _db;

    public HistorialApplication(HistorialContext context) {
      _db = context;
    }

    public async Task<CityData[]> GetHistorial() {
      var results = await _db.City.ToArrayAsync();

      return results.Select(City => {
        return new CityData { Name = City.Name, Country = City.Country, Lat = City.Lat, Lon = City.Lon };
      }).ToArray();

    }

    public async Task<bool> SaveToDB(CityData city) {
      var isCitySaved = await (from cityRegister in _db.City
                               where city.Lat == cityRegister.Lat && city.Lon == cityRegister.Lon
                               select cityRegister).CountAsync() != 0;
      if(isCitySaved) 
        return false;
      else {
        var CityEntity = new CityEntity() {
          ID = Guid.NewGuid().ToString(),
          Name = city.Name,
          Country = city.Country,
          Lat = city.Lat,
          Lon = city.Lon,
        };
        await _db.AddAsync(CityEntity);
        return await _db.SaveChangesAsync() != 0;
      }
    }
  }
}
