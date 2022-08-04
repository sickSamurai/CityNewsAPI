using CityNews_Application.Interfaces;

using CityNews_Domain.Business.NewsApi;
using CityNews_Domain.Entities;

using CityNews_Persistence.Context;

using CityNews_ServiceAgent.NewsAPI;

using Newtonsoft.Json;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace CityNews_Application.Apps {
  public class CityNewsApplication : ICityNewsApplication {
    
    private readonly INewsAPI _newsApi;

    public CityNewsApplication(HistorialContext context, INewsAPI newsApi) {
      
      _newsApi = newsApi;
    }

    public async Task<ResponseEverything> GetNews(string nameCity) {
      ResponseEverything response;
      try {
        response = await _newsApi.Get(nameCity);                        
        return response;
      } catch(Exception ex) {
        return new ResponseEverything() {
          Status = $"¡Error! {ex.Message}",
          Articles = new System.Collections.Generic.List<Articles>()
        };
      }
    }
  }
}
