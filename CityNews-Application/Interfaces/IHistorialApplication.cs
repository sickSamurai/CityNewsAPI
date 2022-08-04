using CityNews_Domain.Business.GeocodingApi;
using CityNews_Domain.Entities;

using System.Threading.Tasks;

namespace CityNews_Application.Interfaces {
  public interface IHistorialApplication {
    Task<CityData[]> GetHistorial();
    Task<bool> SaveToDB(CityData city);
  }
}
