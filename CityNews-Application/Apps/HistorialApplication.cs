using System;
using System.Linq;
using System.Threading.Tasks;

using Application.Interfaces;
using Persistence;
using Domain.Business.GeocodingApi;
using Domain.Entities;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

namespace Application.Apps {
  internal class HistorialApplication : IHistorialApplication {

    private readonly CityNewsDbContext DbContext;

    public HistorialApplication(CityNewsDbContext context) {
      DbContext = context;
    }

    public async Task<CityObject[]> GetHistorial() {
      var results = await DbContext.City.ToArrayAsync();
      return results.Select(city => new CityObject { Name = city.Name, Country = city.Country, Lat = city.Lat, Lon = city.Lon }).ToArray();
    }

    public async Task<bool> SaveToDB(City city) {
      bool isCitySaved = DbContext.City.Where(savedCity => city.Lat == savedCity.Lat && city.Lon == savedCity.Lon).Any();
      if(isCitySaved) {
        return false;
      } else {
        DbContext.Add(city);
        return await DbContext.SaveChangesAsync() != 0;
      }
    }
  }
}
