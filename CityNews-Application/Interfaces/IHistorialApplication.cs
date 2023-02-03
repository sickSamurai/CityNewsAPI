using Domain.Business.GeocodingApi;
using Domain.Entities;

using System.Threading.Tasks;

namespace Application.Interfaces {
  public interface IHistorialApplication {
    Task<CityObject[]> GetHistorial();
    Task<bool> SaveToDB(City city);
  }
}
