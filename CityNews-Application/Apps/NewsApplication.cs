using Application.Interfaces;

using Domain.Business.NewsApi;
using Domain.Entities;

using Newtonsoft.Json;

using System;
using System.Linq;
using System.Threading.Tasks;
using ServiceAgent.NewsAPI;
using Persistence;

namespace Application.Apps
{
    public class NewsApplication : INewsApplication {
    
    private readonly INewsAPI _newsApi;

    public NewsApplication(CityNewsDbContext context, INewsAPI newsApi) {
      
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
